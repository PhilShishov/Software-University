using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class PerformerSongsDto
    {
        [XmlAttribute("id")]
        public int SongId { get; set; }
    }
}
