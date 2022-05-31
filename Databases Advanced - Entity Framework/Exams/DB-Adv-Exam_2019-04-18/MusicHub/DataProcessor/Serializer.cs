namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using MusicHub.DataProcessor.ExportDtos;

    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Songs.Sum(s => s.Price))
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("F2"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToArray(),
                    AlbumPrice = a.Songs.Sum(s => s.Price).ToString("F2")
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(albums, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                        .Include(x => x.SongPerformers)
                        .ThenInclude(x => x.Performer)
                        .Include(x => x.Writer)
                        .Include(x => x.Album)
                        .ThenInclude(x => x.Producer)
                        .ToList()
                        .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                        .Select(s => new ExportSongDto
                        {
                            SongName = s.Name,
                            Writer = s.Writer.Name,
                            Performer = s.SongPerformers
                                .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                .FirstOrDefault(),
                            AlbumProducer = s.Album.Producer.Name,
                            Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture)
                        })
                        .OrderBy(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ThenBy(s => s.Performer)
                        .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSongDto[]), new XmlRootAttribute("Songs"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), songs, namespaces);

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}