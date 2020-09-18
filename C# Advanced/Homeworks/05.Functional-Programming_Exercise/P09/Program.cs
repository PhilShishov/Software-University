using System;
using System.Collections.Generic;
using System.Linq;

namespace P09
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            int end = int.Parse(Console.ReadLine());

            var numbers = Enumerable.Range(1, end).ToList();

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var divider in dividers)
            {
                predicates.Add(x => x % divider == 0);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                foreach (var currentPredicates in predicates)
                {
                    if (!currentPredicates(numbers[i]))
                    {
                        numbers.Remove(numbers[i]);
                        i--;
                        break;
                    }
                }
            }
            print(numbers);

        }
    }
}
