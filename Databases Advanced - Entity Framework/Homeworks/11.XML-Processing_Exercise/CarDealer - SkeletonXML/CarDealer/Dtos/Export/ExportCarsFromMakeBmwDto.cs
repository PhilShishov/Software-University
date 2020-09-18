namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarsFromMakeBmwDto
    {
        [XmlAttribute("id")]
        public int CarId { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }


        //        <cars>
        //  <car id = "7" model="1M Coupe" travelled-distance="39826890" />
        //  <car id = "16" model="E67" travelled-distance="476830509" />
        //  <car id = "5" model="E88" travelled-distance="27453411" />
        //  ...
        //</cars>
    }
}
