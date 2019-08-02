namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoriesByProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }

        //<Category>
        //  <name>Garden</name>
        //  <count>23</count>
        //  <averagePrice>709.94739130434782608695652174</averagePrice>
        //  <totalRevenue>16328.79</totalRevenue>
        //</Category>
    }
}
