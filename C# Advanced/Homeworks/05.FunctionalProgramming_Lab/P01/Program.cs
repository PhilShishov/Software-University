using System;
using System.Linq;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();             

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
