namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Data;
    using Newtonsoft.Json;
    using ImportDto;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movies = JsonConvert.DeserializeObject<Movie[]>(jsonString);

            var sb = new StringBuilder();
            var validMovies = new List<Movie>();

            foreach (var movie in movies)
            {
                var titles = context.Movies.Select(x => x.Title);

                if (!IsValid(movie) || titles.Contains(movie.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validMovies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, $"{movie.Rating:f2}"));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var halls = JsonConvert.DeserializeObject<Halls_SeatsDto[]>(jsonString);

            var sb = new StringBuilder();
            var validHalls = new List<Hall>();

            foreach (var hall in halls)
            {
                if (!IsValid(hall) || hall.Seats < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validHall = new Hall
                {
                    Name = hall.Name,
                    Is4Dx = hall.Is4Dx,
                    Is3D = hall.Is3D
                };

                for (int i = 0; i < hall.Seats; i++)
                {
                    Seat seat = new Seat
                    {
                        Hall = validHall
                    };
                    validHall.Seats.Add(seat);
                }

                var result = "";

                if (validHall.Is3D == true && validHall.Is4Dx == true)
                {
                    result = "4Dx/3D";
                }
                else if (validHall.Is3D == false && validHall.Is4Dx == true)
                {
                    result = "4Dx";
                }
                else if (validHall.Is3D == true && validHall.Is4Dx == false)
                {
                    result = "3D";
                }
                else
                {
                    result = "Normal";
                }

                validHalls.Add(validHall);
                sb.AppendLine(string.Format(SuccessfulImportHallSeat, validHall.Name, result, validHall.Seats.Count));
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectionDto[]),
                new XmlRootAttribute("Projections"));

            var projections = (ProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var validProjections = new List<Projection>();

            foreach (var projection in projections)
            {
                var movie = context.Movies.FirstOrDefault(x => x.Id == projection.MovieId);
                var hall = context.Halls.FirstOrDefault(x => x.Id == projection.HallId);

                if (!IsValid(projection) || movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validProjection = new Projection
                {
                    MovieId = projection.MovieId,
                    HallId = projection.HallId,
                    DateTime = DateTime.ParseExact(projection.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                var validDateTime = validProjection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                validProjections.Add(validProjection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, validDateTime));
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerDto[]),
                new XmlRootAttribute("Customers"));

            var customerDtos = (CustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            var customers = new List<Customer>();
            var tickets = new List<Ticket>();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto) || !customerDto.TicketDtos.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                foreach (var ticketDto in customerDto.TicketDtos)
                {
                    var projection = context.Projections.FirstOrDefault(x => x.Id == ticketDto.ProjectionId);
                    if (projection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var ticket = new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    };

                    tickets.Add(ticket);

                    customer.Tickets.Add(ticket);

                   
                }
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName,
                       customer.LastName, customer.Tickets.Count));

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}