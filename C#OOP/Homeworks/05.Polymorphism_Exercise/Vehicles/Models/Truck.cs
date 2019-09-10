using System;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckSummerConsumption = 1.6;
        private const double InnitialFuelAmount = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumptionPerKm += TruckSummerConsumption;
        }

        public override void Refuel(double litersFuel)
        {
            if (litersFuel <= 0.0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }

            if (litersFuel > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {litersFuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += litersFuel * InnitialFuelAmount;
            }
        }
    }
}
