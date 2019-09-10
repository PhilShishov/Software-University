namespace Vehicles.Core
{
    using System;
    using Vehicles.Models;

    public class Engine
    {
        public void Run()
        {

            Vehicle car = CreateCar();
            Vehicle truck = CreateTruck();
            Vehicle bus = CreateBus();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var commands = Console.ReadLine().Split();

                    string commandType = commands[0];
                    string vehicleType = commands[1];

                    if (commandType == "Drive")
                    {
                        double distance = double.Parse(commands[2]);

                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }

                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }

                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }

                    else if (commandType == "DriveEmpty")
                    {
                        double distance = double.Parse(commands[2]);

                        Console.WriteLine(bus.DriveEmpty(distance));
                    }

                    else if (commandType == "Refuel")
                    {
                        double liters = double.Parse(commands[2]);

                        if (vehicleType == "Car")
                        {
                            car.Refuel(liters);
                        }

                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(liters);
                        }

                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static Bus CreateBus()
        {
            var busInfo = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(busInfo[1]);
            double fuelConsumption = double.Parse(busInfo[2]);
            int tankCapacity = int.Parse(busInfo[3]);

            Bus bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            return bus;
        }

        private static Truck CreateTruck()
        {
            var truckInfo = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(truckInfo[1]);
            double fuelConsumption = double.Parse(truckInfo[2]);
            int tankCapacity = int.Parse(truckInfo[3]);

            Truck truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            return truck;
        }

        private static Car CreateCar()
        {
            var carInfo = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);
            int tankCapacity = int.Parse(carInfo[3]);

            Car car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            return car;
        }
    }
}
