namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Runner
    {
        private List<Car> cars;

        public Runner()
        {
            this.cars = new List<Car>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int line = 0; line < lines; line++)
            {
                string[] parameters = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model)
                    .ToList();

                PrintInfo(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
                    .Select(c => c.Model)
                    .ToList();

                PrintInfo(flamable);
            }
        }

        private void PrintInfo(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Cargo cargo = new Cargo(cargoWeight, cargoType);

            double firstTirePressure = double.Parse(parameters[5]);
            int firstTireAge = int.Parse(parameters[6]);
            Tire firstTire = new Tire(firstTireAge, firstTirePressure);

            double secondTirePressure = double.Parse(parameters[7]);
            int secondTireAge = int.Parse(parameters[8]);
            Tire secondTire = new Tire(secondTireAge, secondTirePressure);

            double thirdTirePressure = double.Parse(parameters[9]);
            int thirdTireAge = int.Parse(parameters[10]);
            Tire thirdTire = new Tire(thirdTireAge, thirdTirePressure);

            double fourthTirePressure = double.Parse(parameters[11]);
            int fourthTireAge = int.Parse(parameters[12]);
            Tire fourthTire = new Tire(fourthTireAge, fourthTirePressure);

            var car = new Car(model, engine, cargo, firstTire, secondTire, thirdTire, fourthTire);

            return car;
        }
    }
}
