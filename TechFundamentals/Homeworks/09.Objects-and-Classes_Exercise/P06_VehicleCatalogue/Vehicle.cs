
namespace P06_VehicleCatalogue
{
    using System;

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
}
