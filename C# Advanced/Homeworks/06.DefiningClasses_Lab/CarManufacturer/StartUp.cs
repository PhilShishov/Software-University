using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Tire> tires = new List<Tire>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = input.Split();

                Tire tireCollection = new Tire(int.Parse(tokens[0]), double.Parse(tokens[1]),
                    int.Parse(tokens[2]), double.Parse(tokens[3]),
                    int.Parse(tokens[4]), double.Parse(tokens[5]),
                    int.Parse(tokens[6]), double.Parse(tokens[7]));

                tires.Add(tireCollection);
            }

            input = string.Empty;

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = input.Split();
                Engine engine = new Engine(int.Parse(tokens[0]), double.Parse(tokens[1]));
                engines.Add(engine);
            }

            input = string.Empty;

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokens = input.Split();
                int engineIndex = int.Parse(tokens[5]);
                int tireIndex = int.Parse(tokens[6]);
                Car car = new Car(tokens[0], tokens[1], int.Parse(tokens[2]),
                    double.Parse(tokens[3]), double.Parse(tokens[4]),
                    engines[engineIndex], tires[tireIndex]);

                cars.Add(car);
            }

            var specialCars = cars
                .Where(x => x.Year >= 2017 
                && x.Engine.HorsePower > 330
                && ((x.Tire.Pressure0 + x.Tire.Pressure1 + x.Tire.Pressure2 + x.Tire.Pressure3) >= 9 
                && (x.Tire.Pressure0 + x.Tire.Pressure1 + x.Tire.Pressure2 + x.Tire.Pressure3) <= 10))
                .ToList();

            for (int i = 0; i < specialCars.Count; i++)
            {
                specialCars[i].FuelQuantity -= (20 * specialCars[i].FuelConsumption) / 100;
            }

            foreach (var car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }

            //var tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //};

            //var engine = new Engine(560, 6300);

            //var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make,model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //Console.WriteLine(firstCar.Make);
            //Console.WriteLine(secondCar.Make + secondCar.Model);
            //Console.WriteLine(thirdCar.Make + thirdCar.FuelConsumption);
        }
    }
}
