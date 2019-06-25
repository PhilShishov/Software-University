
namespace P05_OddTimes
{
    using System;
    using System.Linq;

    class OddTimes
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                result ^= numbers[i];
            }

            Console.WriteLine(result);
        }
    }
}
