
namespace P01_SmallestofThreeNumbers
{
    using System;

    class SmallestofThreeNumbers
    {
        static void Main()
        {
            //int num = 0;

            //GetMin(num);

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = SmallerNumber(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(result);
        }

        static int SmallerNumber(int num1, int num2, int num3)
        {
            int firstSmallerNumber = num1 <= num2 ? num1 : num2;
            int secondSmallerNumber = num1 <= num3 ? num1 : num3;
            return firstSmallerNumber < secondSmallerNumber ? firstSmallerNumber : secondSmallerNumber;
        }

        //public static void GetMin(int num)
        //{
        //    int numMin = int.MaxValue;

        //    for (int i = 0; i < 3; i++)
        //    {
        //        num = int.Parse(Console.ReadLine());
        //        if (numMin > num)
        //        {
        //            numMin = num;
        //        }
        //    }

        //    Console.WriteLine(numMin);
        //}
    }
}
