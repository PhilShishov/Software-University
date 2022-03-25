
namespace P06_EvenandOddSubtraction
{
    using System;
    using System.Linq;

    class EvenandOddSubtraction
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == 0)
                {
                    sumEven += currentNumber;
                }
                else
                {
                    sumOdd += currentNumber;
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
