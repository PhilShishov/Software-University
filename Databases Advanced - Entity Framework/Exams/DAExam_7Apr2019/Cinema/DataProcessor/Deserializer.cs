namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

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
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var sb = new StringBuilder();
            var movies = new List<Movie>();

            foreach (var dto in moviesDto)
            {
                //If a title already exists, do not import it and append an error message.
                var movieExists = movies.Any(m => m.Title == dto.Title);
                var isValidGenre = Enum.TryParse<Genre>(dto.Genre, out Genre genreType);
                var isValid = !IsValid(dto)/* && !isValidGenre && movieExists*/;

                if (isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = dto.Title,
                    Genre = genreType,
                    Duration = dto.Duration,
                    Rating = dto.Rating,
                    Director = dto.Director
                };

                movies.Add(movie);
                sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:F2}!");

            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var sb = new StringBuilder();
            var halls = new List<Hall>();

            foreach (var dto in hallsDto)
            {
                var isValid = !IsValid(dto);

                if (isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = dto.Name,
                    Is4Dx = dto.Is4Dx,
                    Is3D = dto.Is3D
                };

                for (int i = 0; i < dto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);
                sb.AppendLine($"Successfully imported {hall.Name}() with {hall.Seats.Count} seats!");

            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]),
                                            new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var projections = new List<Projection>();

            foreach (var dto in projectionsDto)
            {
                var movie = context.Movies.FirstOrDefault(m => m.Id == dto.MovieId);
                var hall = context.Halls.FirstOrDefault(h => h.Id == dto.HallId);

                if (!IsValid(dto) || movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //  <MovieId>38</MovieId>
                //  <HallId>4</HallId>
                //  <DateTime>2019-04-27 13:33:20</DateTime>


                var projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                sb.AppendLine($"Successfully imported projection {movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                                            new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var customers = new List<Customer>();

            foreach (var dto in customersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                //< Customer >
                //    < FirstName > Randi </ FirstName >
                //    < LastName > Ferraraccio </ LastName >
                //    < Age > 20 </ Age >
                //    < Balance > 59.44 </ Balance >
                //    < Tickets >
                //      < Ticket >
                //        < ProjectionId > 1 </ ProjectionId >
                //        < Price > 7 </ Price >
                //      </ Ticket >

                var customer = new Customer
                {  
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance,
                    Tickets = dto.Tickets.Select(t => new Ticket
                    {
                        ProjectionId = t.ProjectionId,
                        Price = t.Price
                    })
                    .ToArray()
                };

                customers.Add(customer);
                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}
