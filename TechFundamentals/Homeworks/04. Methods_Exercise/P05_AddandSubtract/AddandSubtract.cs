
namespace P05_AddandSubtract
{
    using System;

    class AddandSubtract
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = Substract(firstNum, secondNum, thirdNum);

            Console.WriteLine(result);                
        }

        public static int Sum(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }

        public static int Substract(int num1, int num2, int num3)
        {
            int substract = Sum(num1, num2) - num3;
            return substract;
        }
    }
}
