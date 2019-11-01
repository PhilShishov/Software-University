using System;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            double[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var item in items)
            {
                if (!numbers.ContainsKey(item))
                {
                    numbers.Add(item, 1);
                }
                else
                {
                    numbers[item]++;
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
