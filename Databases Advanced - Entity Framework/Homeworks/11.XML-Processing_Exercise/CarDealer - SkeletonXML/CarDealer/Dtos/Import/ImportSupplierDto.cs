namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportSupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
        //<Supplier>
        //    <name>3M Company</name>
        //    <isImporter>true</isImporter>
        //</Supplier>
    }
}
