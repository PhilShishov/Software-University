
namespace P10_SoftUniExamResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var participants = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>(); ;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }

                string[] tokens = input.Split('-');

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (participants.ContainsKey(name) == false)
                    {
                        participants.Add(name, points);
                    }
                    else
                    {
                        if (participants[name] < points)
                        {
                            participants[name] = points;
                        }
                    }

                    if (submissions.ContainsKey(language) == false)
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    string name = tokens[0];
                    if (participants.ContainsKey(name))
                    {
                        participants.Remove(name);
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var participant in participants.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
