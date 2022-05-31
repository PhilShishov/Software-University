using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportSongDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("CreatedOn")]
        [Required]
        public string CreatedOn { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("AlbumId")]
        public int? AlbumId { get; set; }

        [XmlElement("WriterId")]
        [Required]
        public int WriterId { get; set; }

        [XmlElement("Price")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
