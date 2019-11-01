using System;
using System.Collections.Generic;
using System.Linq;

namespace P06
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carsData = Console.ReadLine().Split();

                Car car = new Car(carsData[0], double.Parse(carsData[1]), double.Parse(carsData[2]));

                if (!cars.Contains(car))
                {
                    cars.Add(car);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string model = tokens[1];
                double distance = double.Parse(tokens[2]);

                // int indexOfCurrentCar = cars.IndexOf(cars.Find(x => x.Model == model));
                // cars[indexOfCurrentCar].Drive(distance);

                Car car = cars.FirstOrDefault(c => c.Model == model);
                car.Drive(distance);

                input = Console.ReadLine();
            }

            foreach (var vehicle in cars)
            {
                Console.WriteLine($"{vehicle.Model} {vehicle.FuelAmount:F2} {vehicle.TravelledDistance}");
            }
        }
    }
}
