namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ImportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("sellerId")]
        public int SellerId { get; set; }
        [XmlElement("buyerId")]
        public int? BuyerId { get; set; }

        //<Product>
        //    <name>Care One Hemorrhoidal</name>
        //    <price>932.18</price>
        //    <sellerId>25</sellerId>
        //    <buyerId>24</buyerId>
        //</Product>
    }
}
