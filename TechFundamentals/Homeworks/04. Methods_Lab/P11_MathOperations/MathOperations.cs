
namespace P11_MathOperations
{
    using System;

    class MathOperations
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            Calculate(a, @operator, b);
        }
        public static double Calculate(int a, string @operator, int b)
        {
            double result = 0;

            switch (@operator)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
            }

            Console.WriteLine($"{result}");
            return result;
        }
    }
}
