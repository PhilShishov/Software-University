
namespace P03_HouseParty
{
    using System;
    using System.Collections.Generic;

    class HouseParty
    {
        static void Main()
        {
            List<string> names = new List<string>();

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split();

                if (input == $"{tokens[0]} is going!")
                {
                    if (names.Contains(tokens[0]))
                    {
                        Console.WriteLine($"{tokens[0]} is already in the list!");
                    }

                    else
                    {
                        names.Add(tokens[0]);
                    }
                }
                else if (input == $"{tokens[0]} is not going!")
                {
                    if (names.Contains(tokens[0]))
                    {
                        names.Remove(tokens[0]);
                    }

                    else
                    {
                        Console.WriteLine($"{tokens[0]} is not in the list!");
                    }
                }
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }            
        }
    }
}
