namespace P01_Concert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Concert
    {
        static void Main()
        {
            var bandsAndMembers = new Dictionary<string, List<string>>();
            var bandsAndTime = new Dictionary<string, int>();

            string input = Console.ReadLine();


            while (input != "start of concert")
            {
                string[] commands = input.Split("; ");

                string command = commands[0];
                string band = commands[1];

                if (command == "Play")
                {
                    int time = int.Parse(commands[2]);

                    if (!bandsAndTime.ContainsKey(band))
                    {
                        bandsAndTime.Add(band, 0);
                        bandsAndMembers.Add(band, new List<string>());
                    }
                    bandsAndTime[band] += time;

                }
                else if (command == "Add")
                {
                    string[] members = commands[2].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                    if (!bandsAndTime.ContainsKey(band))
                    {
                        bandsAndTime.Add(band, 0);
                        bandsAndMembers.Add(band, new List<string>());
                    }
                    foreach (var member in members)
                    {
                        if (!bandsAndMembers[band].Contains(member))
                        {
                            bandsAndMembers[band].Add(member);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            int totalTime = bandsAndTime.Values.Sum();

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var band in bandsAndTime.OrderByDescending(b => b.Value).ThenBy(b => b.Key))
            {
                string bandName = band.Key;
                int time = band.Value;
                Console.WriteLine($"{bandName} -> {time}");
            }

            string bandNameToPrint = Console.ReadLine();

            foreach (var band in bandsAndMembers)
            {
                string bandName = band.Key;
                if (bandName == bandNameToPrint)
                {
                    Console.WriteLine(bandName);
                    foreach (var member in bandsAndMembers[band.Key])
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }
            }
        }
    }
}