namespace BorderControl.Core
{
    using BorderControl.Contracts;
    using BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private List<string> ids;
        private List<string> fakeIds;

        public Engine()
        {
            this.ids = new List<string>();
            this.fakeIds = new List<string>();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                var inputArgs = input.Split();

                if (inputArgs.Length == 2)
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    IRobot robot = new Robot(model, id);
                    ids.Add(id);
                }

                else if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age =int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    ICitizen citizen = new Citizen(name, age, id);
                    ids.Add(id);
                }

                input = Console.ReadLine();
            }

            string digitsToFind = Console.ReadLine();

            fakeIds = ids
                .Select(i => i.Substring(i.Length - digitsToFind.Length))
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fakeIds));
        }
    }
}
