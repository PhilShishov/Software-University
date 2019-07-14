
namespace P08_VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class VehicleCatalogue
    {
        public abstract class Vehicle
        {
            public string Type { get; set; }

            public string Brand { get; set; }

            public string Model { get; set; }

        }

        public class Truck : Vehicle
        {
            public int Weight { get; set; }
        }

        public class Car : Vehicle
        {
            public int HorsePower { get; set; }
        }

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

        static void Main()
        {
            List<Catalog> catalogs = new List<Catalog>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split('/');
                var catalog = new Catalog();

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(tokens[3]);
                    catalog.Car.Type = type;
                    catalog.Car.Brand = brand;
                    catalog.Car.Model = model;
                    catalog.Car.HorsePower = horsePower;
                    catalogs.Add(catalog);
                }

                else if (type == "Truck")
                {
                    int weight = int.Parse(tokens[3]);
                    catalog.Truck.Type = type;
                    catalog.Truck.Brand = brand;
                    catalog.Truck.Model = model;
                    catalog.Truck.Weight = weight;
                    catalogs.Add(catalog);
                }
            }

            List<Catalog> catalogCars = catalogs
                .Where(v => v.Car.Type == "Car")
                .OrderBy(v => v.Car.Brand)
                .ToList();

            List<Catalog> catalogTrucks = catalogs
                .Where(v => v.Truck.Type == "Truck")
                .OrderBy(v => v.Truck.Brand)
                .ToList();

            if (catalogCars.Count > 0)
            {
                Console.WriteLine("Cars:");
            }

            foreach (var vehicle in catalogCars)
            {
                Console.WriteLine($"{vehicle.Car.Brand}: {vehicle.Car.Model} - {vehicle.Car.HorsePower}hp");
            }

            if (catalogTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }

            foreach (var vehicle in catalogTrucks)
            {
                Console.WriteLine($"{vehicle.Truck.Brand}: {vehicle.Truck.Model} - {vehicle.Truck.Weight}kg");
            }
        }
    }
}
