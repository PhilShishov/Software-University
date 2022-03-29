
namespace P08_VehicleCatalogue
{
    using System.Collections.Generic;

    public class Catalog
    {
        public Catalog()
        {
            Truck = new Truck();
            Car = new Car();
        }

        public Truck Truck { get; set; }
        public Car Car { get; set; }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
