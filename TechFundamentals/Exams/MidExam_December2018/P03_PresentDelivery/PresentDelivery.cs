using System;
using System.Linq;

namespace P03_PresentDelivery
{
    class PresentDelivery
    {
        static void Main(string[] args)
        {
            var members = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .Where(i => i % 2 == 0)
                .ToList();

            int index = 0;
            int housesWithPresents = 0;

            string input = Console.ReadLine();

            while (input != "Merry Xmas!")
            {
                var commands = input.Split();
                string command = commands[0];
                int lenght = int.Parse(commands[1]);


                while (members.Count < lenght)
                {
                    lenght -= members.Count;
                }

                if (index + lenght >= members.Count)
                {
                    lenght += index - members.Count;
                }
                else
                {
                    lenght += index;
                }

                for (int i = lenght; i <= members.Count; i++)
                {
                    index = i;
                    if (members[i] == 0)
                    {
                        Console.WriteLine($"House {i} will have a Merry Christmas.");
                        break;
                    }

                    members[i] -= 2;

                    if (members[i] == 0)
                    {
                        housesWithPresents++;
                    }
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Santa's last position was {index}.");

            if (members.All(m => m == 0))
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {members.Count - housesWithPresents} houses.");
            }
        }
    }
}
