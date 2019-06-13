using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.ImportDtos;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesInput = JsonConvert.DeserializeObject<GameDto[]>(jsonString)
                .ToList();

            var games = new List<Game>();
            var sb = new StringBuilder();

            foreach (var gameDto in gamesInput)
            {
                if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                var developer = GetDeveloper(gameDto.Developer, context);
                var genre = GetGanre(gameDto.Genre, context);

                game.Developer = developer;
                game.Genre = genre;

                foreach (var currTag in gameDto.Tags)
                {
                    var tag = GetTag(currTag, context);

                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var users = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var sb = new StringBuilder();
            var usersToAdd = new List<User>();

            foreach (var userDto in users)
            {
                if (!IsValid(userDto) || userDto.Cards.Length == 0 || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };


                foreach (var userDtoCard in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = userDtoCard.Number,
                        Cvc = userDtoCard.CVC,
                        Type = Enum.Parse<CardType>(userDtoCard.Type)
                    });
                }

                usersToAdd.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.AddRange(usersToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseDto[]),
                new XmlRootAttribute("Purchases"));

            var purchases = (PurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var purchasesToAdd = new List<Purchase>();

            foreach (var purchaseDto in purchases)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidEnum = Enum.TryParse(purchaseDto.Type, out PurchaseType result);
                if (!isValidEnum)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);
                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                if (game == null || card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = result,
                    Card = card,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = game,
                    ProductKey = purchaseDto.Key
                };

                purchasesToAdd.Add(purchase);
                sb.AppendLine($"Imported {game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchasesToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }

        private static Tag GetTag(string tagName, VaporStoreDbContext context)
        {
            var tag = context.Tags.FirstOrDefault(x => x.Name == tagName);

            if (tag == null)
            {
                tag = new Tag
                {
                    Name = tagName
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }

        private static Genre GetGanre(string genreName, VaporStoreDbContext context)
        {
            var genre = context.Genres
                .FirstOrDefault(x => x.Name == genreName);

            if (genre == null)
            {
                genre = new Genre()
                {
                    Name = genreName
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(string gameDeveloperName, VaporStoreDbContext context)
        {
            var developer = context.Developers
                .FirstOrDefault(x => x.Name == gameDeveloperName);

            if (developer == null)
            {
                developer = new Developer
                {
                    Name = gameDeveloperName
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }
    }
}