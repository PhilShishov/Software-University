namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarsWithDistanceDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }

        //<car>
        //  <make>BMW</make>
        //  <model>1M Coupe</model>
        //  <travelled-distance>39826890</travelled-distance>
        //</car>

    }
}
