
namespace P09_MultiplyEvensbyOdds
{
    using System;

    class MultiplyEvensbyOdds
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int result = GetMultipleOfEvenAndOdds(Math.Abs(number));
            Console.WriteLine(result);
        }

        public static int GetMultipleOfEvenAndOdds(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        public static int GetSumOfEvenDigits(int number)
        {
            return GetSumOfDigits(number, 0);
        }

        public static int GetSumOfOddDigits(int number)
        {
            return GetSumOfDigits(number, 1);
        }

        public static int GetSumOfDigits(int number, int expectedRemainder)
        {
            int sum = 0;

            while (number > 0)
            {
                int last = number % 10;
                number /= 10;

                if (last % 2 == expectedRemainder)
                {
                    sum += last;
                }
            }

            return sum;
        }
    }
}
