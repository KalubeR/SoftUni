using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.ExportDtos;
using Formatting = Newtonsoft.Json.Formatting;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Where(g => g.Purchases.Any())
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToList(),
                    TotalPlayers = x.Games.Sum(y => y.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();


            var json = JsonConvert.SerializeObject(genres, Formatting.Indented);
            return json;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]),
                new XmlRootAttribute("Users"));

            var type = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Select(x => new ExportUserDto
                {
                    Username = x.Username,
                    PurchaseDtos = x.Cards
                        .SelectMany(p => p.Purchases)
                        .Where(p => p.Type == type)
                        .Select(p => new ExportPurchaseDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price,
                                Title = p.Game.Name
                            }
                        })
                        .OrderBy(d => d.Date)
                        .ToList(),
                    TotalSpent = x.Cards.SelectMany(p => p.Purchases)
                        .Where(p => p.Type == type)
                        .Sum(p => p.Game.Price)
                })
                .Where(p => p.PurchaseDtos.Any())
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("", ""), 
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
	}
}