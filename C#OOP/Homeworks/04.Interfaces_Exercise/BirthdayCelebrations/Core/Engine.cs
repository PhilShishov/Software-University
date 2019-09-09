namespace BorderControl.Core
{
    using BirthdayCelebrations.Contracts;
    using BirthdayCelebrations.Models;
    using BorderControl.Contracts;
    using BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Engine
    {
        private List<DateTime> birthdays;

        public Engine()
        {
            this.birthdays = new List<DateTime>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                var inputArgs = input.Split();

                if (inputArgs.Length == 5)
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    DateTime birthday = DateTime.ParseExact(inputArgs[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    ICitizen citizen = new Citizen(name, age, id, birthday);
                    birthdays.Add(birthday);
                }
                else if (inputArgs.Length == 3)
                {
                    string type = inputArgs[0];

                    if (type == "Robot")
                    {
                        string model = inputArgs[1];
                        string id = inputArgs[2];

                        IRobot robot = new Robot(model, id);
                    }

                    else
                    {
                        string name = inputArgs[1];
                        DateTime birthday = DateTime.ParseExact(inputArgs[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        IPet pet = new Pet(name, birthday);
                        birthdays.Add(birthday);
                    }
                }

                input = Console.ReadLine();
            }

            int yearToFind = int.Parse(Console.ReadLine());

            birthdays = birthdays
                .Where(b => b.Year == yearToFind)
                .ToList();

            foreach (var birthday in birthdays)
            {
                Console.WriteLine(birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            }
        }
    }
}
