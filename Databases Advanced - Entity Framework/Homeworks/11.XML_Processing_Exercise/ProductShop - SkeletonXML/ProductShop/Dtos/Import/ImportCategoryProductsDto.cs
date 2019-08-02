namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportCategoryProductsDto
    {
        [XmlElement]
        public int CategoryId { get; set; }

        [XmlElement]
        public int ProductId { get; set; }

        //<CategoryProduct>
        //    <CategoryId>4</CategoryId>
        //    <ProductId>1</ProductId>
        //</CategoryProduct>
    }
}
