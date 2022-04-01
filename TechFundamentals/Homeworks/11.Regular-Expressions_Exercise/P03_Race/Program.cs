
namespace P03_Race
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string[] contestants =
                Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string input = Console.ReadLine();
            var results = new Dictionary<string, int>();
            while (input != "end of race")
            {
                string namePattern = @"[A-Za-z]";
                string digitsPattern = @"\d";

                var nameMatch = Regex.Matches(input, namePattern);
                var kmMatch = Regex.Matches(input, digitsPattern);

                var name = String.Concat(nameMatch);
                var sum = kmMatch.Select(x => int.Parse(x.Value)).Sum();

                if (contestants.Contains(name))
                {
                    if (results.ContainsKey(name))
                    {
                        results[name] += sum;
                    }
                    else
                    {
                        results.Add(name, sum);
                    }

                }
                input = Console.ReadLine();

            }
            var sorted = results.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }
    }
}
