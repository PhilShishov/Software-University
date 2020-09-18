
namespace P02_DungeonestDark
{
    using System;

    class DungeonestDark
    {
        static void Main()
        {
            int health = 100;
            int coins = 0;

            string[] commands = Console.ReadLine().Split("|");

            for (int i = 0; i < commands.Length; i++)
            {
                string[] rooms = commands[i].Split();
                string roomName = rooms[0];
                int number = int.Parse(rooms[1]);

                if (roomName == "potion")
                {
                    if (health == 100)
                    {
                        Console.WriteLine($"You healed for 0 hp.");
                    }

                    else if (health + number <= 100)
                    {
                        health += number;
                        Console.WriteLine($"You healed for {number} hp.");
                    }

                    else if (health + number > 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }

                    Console.WriteLine($"Current health: {health} hp.");
                }

                else if (roomName == "chest")
                {
                    coins += number;
                    Console.WriteLine($"You found {number} coins.");
                }

                else
                {
                    if (health - number > 0)
                    {
                        health -= number;
                        Console.WriteLine($"You slayed {roomName}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {roomName}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
