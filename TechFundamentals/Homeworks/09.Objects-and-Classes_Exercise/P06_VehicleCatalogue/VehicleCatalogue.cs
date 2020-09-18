
namespace P06_VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class VehicleCatalogue
    {
        public class Vehicle
        {
            public Vehicle(string typeVehicle, string model, string color, int horsePower)
            {
                TypeVehicle = typeVehicle;
                Model = model;
                Color = color;
                HorsePower = horsePower;
            }

            public string TypeVehicle { get; set; }

            public string Model { get; set; }

            public string Color { get; set; }

            public int HorsePower { get; set; }

            public void PrintVehicle(Vehicle vehicle)
            {
                Console.WriteLine($"Type: {TypeVehicle}");
                Console.WriteLine($"Model: {Model}");
                Console.WriteLine($"Color: {Color}");
                Console.WriteLine($"Horsepower: {HorsePower}");
            }
        }

        static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            double averageHPCar = 0;
            double averageHPTruck = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] vehicleProps = input.Split();

                string typeVehicle = UppercaseFirst(vehicleProps[0]);

                string model = vehicleProps[1];
                string color = vehicleProps[2];
                int horsePower = int.Parse(vehicleProps[3]);

                if (typeVehicle == "Car")
                {
                    averageHPCar += horsePower;
                }

                else if (typeVehicle == "Truck")
                {
                    averageHPTruck += horsePower;
                }

                var vehicle = new Vehicle(typeVehicle, model, color, horsePower);

                vehicles.Add(vehicle);
            }

            List<Vehicle> listCars = vehicles.Where(v => v.TypeVehicle == "Car").ToList();
            List<Vehicle> listTrucks = vehicles.Where(v => v.TypeVehicle == "Truck").ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Close the Catalogue")
                {
                    break;
                }

                foreach (Vehicle vehicle in vehicles.Where(v => v.Model == input))
                {
                    vehicle.PrintVehicle(vehicle);
                }
            }

            if (listCars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageHPCar / listCars.Count:F2}.");
            }

            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }

            if (listTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageHPTruck / listTrucks.Count:F2}.");
            }

            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }

        }

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
