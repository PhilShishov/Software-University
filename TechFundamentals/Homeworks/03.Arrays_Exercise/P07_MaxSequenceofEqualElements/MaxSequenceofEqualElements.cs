
namespace P07_MaxSequenceofEqualElements
{
    using System;
    using System.Linq;

    class MaxSequenceofEqualElements
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int start = 0;
            int bestStart = 0;
            int length = 0;
            int bestLength = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[start] == numbers[i])
                {
                    length++;
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestStart = start;
                    }
                }
                else
                {
                    start++;
                    i = start;
                    length = 0;
                }
            }
            for (int i = 0; i <= bestLength; i++)
            {
                Console.Write(numbers[bestStart + i] + " ");
            }
            Console.WriteLine();

        }
    }
}
