using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            var platesInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> plates = new List<int>(platesInput);
            Stack<int> warriors = new Stack<int>();

            for (int wave = 1; wave <= waves; wave++)
            {
                var warriorsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                foreach (var warrior in warriorsInput)
                {
                    warriors.Push(warrior);
                }

                if (wave % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());

                    plates.Add(additionalPlate);
                }

                while (warriors.Count > 0 && plates.Count > 0)
                {
                    int currentPlate = plates[0];
                    int currentWarrior = warriors.Pop();

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        warriors.Push(currentWarrior);
                        plates.RemoveAt(0);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        currentPlate -= currentWarrior;
                        plates[0] = currentPlate;
                    }
                    else if (currentWarrior == currentPlate)
                    {
                        plates.RemoveAt(0);
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
        }
    }
}
