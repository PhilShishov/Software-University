namespace P07
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                Engine engine = new Engine()
                {
                    EngineSpeed = int.Parse(carData[1]),
                    EnginePower = int.Parse(carData[2])
                };

                Cargo cargo = new Cargo()
                {
                    CargoWeight = int.Parse(carData[3]),
                    CargoType = carData[4]
                };

                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 4; j += 2)
                {
                    double pressure = double.Parse(carData[5 + j]);
                    int year = int.Parse(carData[6 + j]);

                    Tire tire = new Tire(pressure, year);

                    tires.Add(tire);
                }

                //Tire tire = new Tire()
                //{
                //    Pressure1 = double.Parse(carData[5]),
                //    Age1 = int.Parse(carData[6]),
                //    Pressure2 = double.Parse(carData[7]),
                //    Age2 = int.Parse(carData[8]),
                //    Pressure3 = double.Parse(carData[9]),
                //    Age3 = int.Parse(carData[10]),
                //    Pressure4 = double.Parse(carData[11]),
                //    Age4 = int.Parse(carData[12])
                //};

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string line = Console.ReadLine();

            if (line == "flamable")
            {
                cars = cars.Where(c => c.Cargo.CargoType == line && c.Engine.EnginePower > 250).ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else
            {
                cars = cars.Where(c => c.Cargo.CargoType == line && c.Tires.Any(t => t.Pressure < 1)).ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}
