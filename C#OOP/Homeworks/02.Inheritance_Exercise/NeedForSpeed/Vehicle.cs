namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        //private double fuelConsumption;

        protected Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double leftFuel = this.Fuel - this.FuelConsumption * kilometers;

            if (leftFuel >= 0)
            {
                this.Fuel -= this.FuelConsumption * kilometers;
            }
        }
    }
}
