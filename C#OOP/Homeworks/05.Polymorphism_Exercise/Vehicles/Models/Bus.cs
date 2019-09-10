namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double BusSummerConsumption = 1.4;    

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumptionPerKm += BusSummerConsumption;
        }        
    }
}
