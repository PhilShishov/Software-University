using System;
using System.Collections.Generic;
using System.Linq;

namespace P05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new KeyValuePair<string, int>(person[0], int.Parse(person[1])));
            }

            string condition = Console.ReadLine();
            int age = Int32.Parse(Console.ReadLine());

            string[] printPattern = Console.ReadLine()
                .Split();

            var filtered = people
                .Where(p => condition == "younger" ? p.Value < age : p.Value >= age)
                .ToList();

            foreach (var kvp in filtered)
            {
                if (printPattern.Length == 2)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
                else
                {
                    Console.WriteLine(printPattern[0] == "name" ? 
                        $"{kvp.Key}" :
                        $"{kvp.Value}");
                } 
            }
        }
    }
}
