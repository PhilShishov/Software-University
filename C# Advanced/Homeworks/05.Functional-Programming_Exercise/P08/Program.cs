using System;
using System.Linq;

namespace P08
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));
            Func<int, int, int> sortFunc = (a, b) =>
                                (a % 2 == 0 && b % 2 != 0) ? -1 :
                                (a % 2 != 0 && b % 2 == 0) ? 1 :
                                a.CompareTo(b); //x`> y ? 1 : x < y ? -1 : 0;

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(inputNumbers, new Comparison<int>(sortFunc));

            print(inputNumbers);

        }
    }
}
