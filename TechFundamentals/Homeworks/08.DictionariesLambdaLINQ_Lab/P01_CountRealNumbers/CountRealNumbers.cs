
namespace P01_CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountRealNumbers
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (int number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts.Add(number, 1);
                }
            }

            foreach (var number in counts)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
