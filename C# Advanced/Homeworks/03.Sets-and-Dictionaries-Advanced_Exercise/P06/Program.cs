using System;
using System.Collections;
using System.Collections.Generic;

namespace P06
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] clothes = input[1].Split(",");

                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] clothToLookFor = Console.ReadLine().Split();
            string targetColor = clothToLookFor[0];
            string targetCloth = clothToLookFor[1];

            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (cloth, count) in clothes)
                {
                    string result = $"* {cloth} - {count}";

                    if (cloth == targetCloth && color == targetColor)
                    {
                        result +=" (found!)";
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}
