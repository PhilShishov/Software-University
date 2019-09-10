namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarSummerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumptionPerKm += CarSummerConsumption;
        }
    }
}
