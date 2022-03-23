
namespace M_P05_RefactoringPrimeChecker
{
    using System;

    class RefactoringPrimeChecker
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            for (int number = 2; number <= range; number++)
            {
                bool isPrimeNumber = true;
                for (int divider = 2; divider < number; divider++)
                {
                    if (number % divider == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                }
                Console.WriteLine($"{number} -> {isPrimeNumber.ToString().ToLower()}");
            }

        }
    }
}
