namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count >= 1))                                
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections
                                 .SelectMany(p =>p.Tickets)
                                 .Select(t => t.Customer)
                                 .Select(c => new
                                 {
                                     FirstName = c.FirstName,
                                     LastName = c.LastName,
                                     Balance = c.Balance.ToString("F2")
                                 })
                                 .OrderByDescending(c => c.Balance)
                                 .ThenBy(c => c.FirstName)
                                 .ThenBy(c => c.LastName)
                                 .ToArray()
                })
                .Take(10)
                .ToArray();
             

            string json = JsonConvert.SerializeObject(movies, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            throw new NotImplementedException();
        }
    }
}