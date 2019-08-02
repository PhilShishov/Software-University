
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportCustomUserProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUsersWithProductsDto[] ExportUsersWithProductsDto { get; set; }
    }
}
