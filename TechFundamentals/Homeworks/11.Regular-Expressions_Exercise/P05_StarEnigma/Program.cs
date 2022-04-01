
namespace P05_StarEnigma
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            List<string> attPlanet = new List<string>();
            List<string> deffPlanet = new List<string>();

            string keyPattern = "[STARstar]";
            string path = @"@([A-Za-z]+)[^@\-!:>]*:([0-9]+)[^@\-!:>]*(!D!|!A!)[^@\-!:>]*->([0-9]+)";

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                StringBuilder sb = new StringBuilder();
                string input = Console.ReadLine();

                int count = Regex.Matches(input, keyPattern).Count;

                foreach (var item in input)
                {
                    sb.Append((char)(item - count));
                }

                Match match = Regex.Match(sb.ToString(), path);

                if (!match.Success)
                {
                    continue;
                }

                string planetName = match.Groups[1].Value;
                int population = int.Parse(match.Groups[2].Value);
                string atk = match.Groups[3].Value;
                int soldiers = int.Parse(match.Groups[4].Value);

                if (atk == "!A!")
                {
                    attPlanet.Add(planetName);
                }
                else
                {
                    deffPlanet.Add(planetName);
                }
            }

            Console.WriteLine($"Attacked planets: {attPlanet.Count}");

            foreach (var item in attPlanet.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {deffPlanet.Count}");
            foreach (var item in deffPlanet.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
