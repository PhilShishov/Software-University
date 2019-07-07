
namespace P04_IronGirder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class IronGinder
    {
        static void Main()
        {
            var townsAndTime = new Dictionary<string, int>();
            var townsAndPassengers = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Slide rule")
            {
                string[] tokens = input.Split(new[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);

                string town = tokens[0];
                int passengers = int.Parse(tokens[2]);

                if (tokens[1] == "ambush")
                {
                    if (townsAndTime.ContainsKey(town))
                    {
                        townsAndTime[town] = 0;
                        townsAndPassengers[town] -= passengers;
                    }
                }

                else
                {
                    int time = int.Parse(tokens[1]);

                    if (!townsAndTime.ContainsKey(town))
                    {
                        townsAndTime.Add(town, time);
                        townsAndPassengers.Add(town, 0);
                    }

                    townsAndPassengers[town] += passengers;

                    if (townsAndTime[town] > time || townsAndTime[town] == 0)
                    {
                        townsAndTime[town] = time;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var town in townsAndTime.OrderBy(t => t.Value)
                .ThenBy(t => t.Key)
                .Where(t => t.Value != 0))
            {
                if (townsAndPassengers[town.Key] > 0)
                {
                    string townName = town.Key;
                    int bestTime = town.Value;
                    int totalCountPassengers = townsAndPassengers[town.Key];
                    Console.WriteLine($"{townName} -> Time: {bestTime} -> Passengers: {totalCountPassengers}");
                }
            }
        }
    }
}
