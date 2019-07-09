
namespace P02_BakingRush
{
    using System;

    class BakingRush
    {
        static void Main()
        {
            int initialEnergy = 100;
            int initialCoins = 100;
            string[] commands = Console.ReadLine().Split("|");

            foreach (var command in commands)
            {
                string[] tokens = command.Split("-");
                string eventName = tokens[0];
                int number = int.Parse(tokens[1]);

                if (eventName == "rest")
                {
                    if (initialEnergy + number > 100)
                    {
                        Console.WriteLine("You gained 0 energy.");
                    }
                    else
                    {
                        initialEnergy += number;
                        Console.WriteLine($"You gained {number} energy.");
                    }
                    Console.WriteLine($"Current energy: {initialEnergy}.");
                }

                else if (eventName == "order")
                {
                    if (initialEnergy - 30 >= 0)
                    {
                        initialCoins += number;
                        initialEnergy -= 30;
                        Console.WriteLine($"You earned {number} coins.");
                    }
                    else
                    {
                        initialEnergy += 50;
                        Console.WriteLine("You had to rest!");
                    }
                }

                else
                {
                    if (initialCoins - number > 0)
                    {
                        initialCoins -= number;
                        Console.WriteLine($"You bought {eventName}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {eventName}.");
                        return;
                    }
                }
            }


            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {initialCoins}");
            Console.WriteLine($"Energy: {initialEnergy}");
        }
    }
}

