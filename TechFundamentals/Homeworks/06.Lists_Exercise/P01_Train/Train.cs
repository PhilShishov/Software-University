
namespace P01_Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Train
    {
        static void Main()
        {
            List<int> currentPassengers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxWagonCapacity = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int wagonToAdd = int.Parse(tokens[1]);
                        currentPassengers.Add(wagonToAdd);
                        break;

                    default:
                        for (int i = 0; i < currentPassengers.Count; i++)
                        {
                            int passengersToAdd = int.Parse(tokens[0]);

                            if (currentPassengers[i] + passengersToAdd <= maxWagonCapacity)
                            {
                                currentPassengers[i] += passengersToAdd;
                                break;
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", currentPassengers));
        }
    }
}
