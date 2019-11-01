
namespace P07_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Queue<int[]> petrolPumps = new Queue<int[]>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int[] petrolPump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                petrolPumps.Enqueue(petrolPump);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var petrolPump in petrolPumps)
                {
                    int amount = petrolPump[0];
                    int distance = petrolPump[1];

                    totalFuel += amount - distance;

                    if (totalFuel < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
