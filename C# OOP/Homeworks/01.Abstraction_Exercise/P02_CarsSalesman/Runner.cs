namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Runner
    {
        private List<Car> cars;
        private List<Engine> engines;

        public Runner()
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
        }

        public void Start()
        {
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = this.CreateEngine(parameters);

                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private Car CreateCar(string[] parameters)
        {
            Car car = null;

            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            if (parameters.Length == 3)
            {
                bool isWeight = int.TryParse(parameters[2], out int weight);

                if (isWeight)
                {
                    car = new Car(model, engine, weight);
                }

                else
                {
                    string color = parameters[2];
                    car = new Car(model, engine, color);
                }
            }
            
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                int weight = int.Parse(parameters[2]);
                car = new Car(model, engine, weight, color);
            }
            else
            {
                car = new Car(model, engine);
            }

            return car;
        }

        private Engine CreateEngine(string[] parameters)
        {
            Engine engine = null;

            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            if (parameters.Length == 3)
            {
                bool isDisplacement = int.TryParse(parameters[2], out int displacement);

                if (isDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    string efficiency = parameters[2];
                    engine = new Engine(model, power, efficiency);
                }
            }

            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                int displacement = int.Parse(parameters[2]);
                engine = new Engine(model, power, displacement, efficiency);
            }
            else
            {
                engine = new Engine(model, power);
            }

            return engine;
        }
    }
}
