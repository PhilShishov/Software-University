namespace P06
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            if (this.FuelConsumption * distance > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= this.FuelConsumption * distance;
                this.TravelledDistance += distance;
            }
        }
    }
}
