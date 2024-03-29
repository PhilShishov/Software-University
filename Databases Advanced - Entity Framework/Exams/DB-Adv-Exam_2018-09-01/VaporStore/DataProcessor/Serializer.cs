﻿namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using Data;

    using Newtonsoft.Json;

    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDtos;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .ToArray()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(game => game.Purchases.Count > 0)
                    .Select(game => new
                    {
                        Id = game.Id,
                        Title = game.Name,
                        Developer = game.Developer.Name,
                        Tags = string.Join(", ", game.GameTags.Select(t => t.Tag.Name).ToArray()),
                        Players = game.Purchases.Count
                    })
                    .OrderByDescending(x => x.Players)
                    .ThenBy(x => x.Id)
                    .ToArray(),
                    TotalPlayers = g.Games.Sum(game => game.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            string json = JsonConvert.SerializeObject(genres, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var storeTypeValue = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .ToArray()
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type == storeTypeValue)
                        .Select(p => new ExportPurchaseDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Genre = p.Game.Genre.Name,
                                Title = p.Game.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray(),
                    TotalSpent = u.Cards
                            .SelectMany(c => c.Purchases)
                            .Where(p => p.Type == storeTypeValue)
                            .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}