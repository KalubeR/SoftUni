namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(y => y.Tickets.Count >= 1))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = $"{x.Rating:f2}",
                    TotalIncomes = x.Projections.Select(t => t.Tickets.Sum(y => y.Price)).Sum().ToString("f2"),
                    Customers = x.Projections
                    .SelectMany(c => c.Tickets).Select(p => new
                    {
                        FirstName = p.Customer.FirstName,
                        LastName = p.Customer.LastName,
                        Balance = $"{p.Customer.Balance:f2}"
                    })
                    .OrderByDescending(b => b.Balance)
                    .ThenBy(f => f.FirstName)
                    .ThenBy(l => l.LastName)
                    .ToList()
                })
                .OrderByDescending(m => decimal.Parse(m.Rating))
                .OrderByDescending(t => decimal.Parse(t.TotalIncomes))
                .Take(10);

            var usersJson = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
            return usersJson;
        }
        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var users = context.Customers
                .Where(c => c.Age >= age)
                .Select(x => new CustomerExportDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    //SpentMoney = TimeSpan.ParseExact(x.Tickets.Sum(y => y.Projection.Movie.Duration.Seconds.ToString())
                    //, "hh\\:mm\\:s", CultureInfo.InvariantCulture, out long result),
                    SpentTime = x.Tickets.Sum(y => y.Projection.Movie.Duration.Ticks)
                    //SpentTime = TimeSpan.FromTicks(x.Tickets.Sum(y => y.Projection.Movie.Duration.Ticks))
                    //SpentTime2 = result

                })
                .OrderByDescending(x => x.SpentMoney)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CustomerExportDto[]),
                new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
               new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}