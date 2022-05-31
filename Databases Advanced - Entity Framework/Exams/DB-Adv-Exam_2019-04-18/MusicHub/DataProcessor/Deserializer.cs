namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;

    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;

    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<Writer[]>(jsonString);

            var sb = new StringBuilder();
            var writers = new List<Writer>();

            foreach (var dto in writersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine($"Imported {writer.Name}");

            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var sb = new StringBuilder();
            var producers = new List<Producer>();

            foreach (var dto in producersDto)
            {
                if (!IsValid(dto) || !dto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym,
                    PhoneNumber = dto.PhoneNumber,
                };

                foreach (var albumDto in dto.Albums)
                {
                    producer.Albums.Add(new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    });
                }

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine($"Imported {producer.Name} with no phone number produces {producer.Albums.Count} albums");
                }

                else
                {
                    sb.AppendLine($"Imported {producer.Name} with phone: {producer.PhoneNumber} produces {producer.Albums.Count} albums");
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]),
                                            new XmlRootAttribute("Songs"));

            var songsDto = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var songs = new List<Song>();

            foreach (var dto in songsDto)
            {
                var isValidGenre = Enum.TryParse<Genre>(dto.Genre, out Genre genreType);
                var isValid = !IsValid(dto) || !isValidGenre;

                var albumId = context.Albums.FirstOrDefault(a => a.Id == dto.AlbumId);
                var writerId = context.Writers.FirstOrDefault(w => w.Id == dto.WriterId);

                if (isValid || albumId == null || writerId == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = dto.Name,
                    Duration = TimeSpan.Parse(dto.Duration),
                    CreatedOn = DateTime.ParseExact(dto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genreType,
                    AlbumId = dto.AlbumId,
                    WriterId = dto.WriterId,
                    Price = dto.Price
                };

                songs.Add(song);
                sb.AppendLine($"Imported {song.Name} ({song.Genre} genre) with duration {song.Duration}");
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]),
                                           new XmlRootAttribute("Performers"));

            var performersDto = (ImportPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var performers = new List<Performer>();

            foreach (var dto in performersDto)
            {
                var isSongValid = true;

                foreach (var songDto in dto.PerformersSongs)
                {
                    var song = context.Songs.FirstOrDefault(s => s.Id == songDto.SongId);
                    if (song == null)
                    {
                        isSongValid = false;
                        break;
                    }
                }

                if (!IsValid(dto) || !isSongValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;

                }

                var performer = new Performer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    NetWorth = dto.NetWorth
                };

                foreach (var songDto in dto.PerformersSongs)
                {
                    performer.PerformerSongs.Add(new SongPerformer
                    {
                        SongId = songDto.SongId
                    });
                }

                performers.Add(performer);
                sb.AppendLine($"Imported {performer.FirstName} ({performer.PerformerSongs.Count} songs)");
            }

            context.Performers.AddRange(performers);
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