
namespace P06_EqualSum
{
    using System;
    using System.Linq;

    class EqualSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rightSum = 0;
            int leftSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum += numbers[i];
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum -= numbers[i];
                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum += numbers[i];
            }
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    int rightSum = 0;
            //    int leftSum = 0;
            //    for (int rightSide = i + 1; rightSide < numbers.Length; rightSide++)
            //    {
            //        rightSum += numbers[rightSide];
            //    }
            //    for (int leftSide = 0; leftSide < i; leftSide++)
            //    {
            //        leftSum += numbers[leftSide];
            //    }
            //    if (rightSum == leftSum)
            //    {
            //        Console.WriteLine(i);
            //        return;
            //    }
            //}

            Console.WriteLine("no");



        }
    }
}
