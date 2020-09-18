using System;
using System.Linq;

namespace P05
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            MergeSort<int>.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
