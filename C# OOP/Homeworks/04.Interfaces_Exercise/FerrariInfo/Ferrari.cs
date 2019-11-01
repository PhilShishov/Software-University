namespace FerrariInfo
{
    public class Ferrari : ICar
    {
        private const string ModelName = "488-Spider";

        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string Model => ModelName;

        public string DriverName { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.DriverName}";
        }
    }
}
