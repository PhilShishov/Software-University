
namespace P10_RefactorSpecialNumbers
{
    using System;

    class RefactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isSpecialNumber = false;
            for (int i = 1; i <= n; i++)
            {
                int sumOfDigits = 0;
                int digits = i;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }
                isSpecialNumber = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine($"{i} -> {isSpecialNumber}");
            }

        }
    }
}
