
namespace P08_FactorialDivision
{
    using System;

    class FactorialDivision
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long firstFact = Factorial(firstNumber);
            long secondFact = Factorial(secondNumber);

            double result = Divide(firstFact, secondFact);
            Console.WriteLine($"{result:F2}");
        }

        public static double Divide(long num1, long num2)
        {
            return (double)num1 / num2;
        }

        public static long Factorial(int number)
        {
            long factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
