using System;
using System.Collections.Generic;
using System.Linq;

namespace P04
{
    class Program
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int minBound = bounds[0];
            int maxBound = bounds[1];

            List<int> nums = new List<int>();

            for (int i = minBound; i <= maxBound; i++)
            {
                nums.Add(i);
            }

            string command = Console.ReadLine();

            Predicate<int> isEven = number 
                => number % 2 == 0;
            Predicate<int> isOdd = number 
                => number % 2 != 0;

            Action<List<int>> print = numbers 
                => Console.WriteLine(string.Join(" ", numbers));

            if (command == "odd")
            {
               nums = nums.Where(x => isOdd(x)).ToList();
            }
            else
            {
                nums = nums.Where(x => isEven(x)).ToList();
            }

            print(nums);
        }       
    }
}
