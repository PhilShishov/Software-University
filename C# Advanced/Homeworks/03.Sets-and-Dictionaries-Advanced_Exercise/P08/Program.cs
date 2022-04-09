using System;
using System.Collections.Generic;
using System.Linq;

namespace P08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var totalPoints = new Dictionary<string, int>();
            var participants = new SortedDictionary<string, Dictionary<string, int>>();

            string command = "";

            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = command.Split(':');
                contests.Add(tokens[0], tokens[1]);
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = command.Split("=>");
                string contestName = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == password)
                {
                    if (!participants.ContainsKey(username))
                    {
                        participants.Add(username, new Dictionary<string, int>());
                        totalPoints.Add(username, 0);
                    }

                    if (!participants[username].ContainsKey(contestName))
                    {
                        participants[username].Add(contestName, points);
                        totalPoints[username] += points;
                    }
                    else
                    {
                        int oldPoints = participants[username][contestName];

                        if (oldPoints < points)
                        {
                            participants[username][contestName] = points;
                            totalPoints[username] += points - oldPoints;
                        }
                    }
                }

            }

            var bestParticipant = totalPoints
                .OrderByDescending(x => x.Value)
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestParticipant.Key} with total {bestParticipant.Value} points.");

            Console.WriteLine("Ranking:");

            foreach (var participant in participants)
            {
                Console.WriteLine(participant.Key);

                foreach (var contest in participant.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
