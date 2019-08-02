
namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class PartIdDto
    {
        [XmlElement("id")]
        public int PartId { get; set; }
    }
}
