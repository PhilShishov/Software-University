using System;
using System.Linq;

namespace P06
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

            nums.Sort();

            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
