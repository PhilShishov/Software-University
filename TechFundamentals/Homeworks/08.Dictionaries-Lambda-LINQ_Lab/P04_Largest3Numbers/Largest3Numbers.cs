
namespace P04_Largest3Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Largest3Numbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));

            //var sorted = numbers.OrderByDescending(n => n).ToArray();

            //for (int i = 0; i < 3; i++)
            //{
            //    if (i == sorted.Length)
            //    {
            //        break;
            //    }
            //    Console.Write(sorted[i] + " ");

            //}
            //Console.WriteLine();
        }
    }
}
