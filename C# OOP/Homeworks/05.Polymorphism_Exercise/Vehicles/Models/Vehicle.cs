namespace Vehicles.Models
{
    using System;
    using Vehicles.Contracts;
    using Vehicles.Exceptions;

    public abstract class Vehicle : IVehicle
    {
        private const double BusSummerConsumption = 1.4;
        private int tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionPerKm { get; protected set; }

        public int TankCapacity
        {
            get => this.tankCapacity;

            protected set
            {
                if (value < this.FuelQuantity)
                {
                    this.FuelQuantity = 0;
                }

                this.tankCapacity = value;
            }
        }

        public virtual string Drive(double distance)
        {
            if (distance * this.FuelConsumptionPerKm < this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual string DriveEmpty(double distance)
        {
            this.FuelConsumptionPerKm -= BusSummerConsumption;

            if (distance * this.FuelConsumptionPerKm < this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double litersFuel)
        {
            if (litersFuel <= 0.0)
            {
                throw new NegativeFuelException();
            }

            if (litersFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litersFuel} fuel in the tank");
            }

            this.FuelQuantity += litersFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
