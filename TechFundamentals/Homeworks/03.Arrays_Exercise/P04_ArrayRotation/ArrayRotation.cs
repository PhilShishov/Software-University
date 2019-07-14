
namespace P04_ArrayRotation
{
    using System;
    using System.Linq;

    class ArrayRotation
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());
            int[] rotatedNumbers = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                rotatedNumbers[i] = numbers[(i + rotations) % numbers.Length];
            }
            Console.WriteLine(string.Join(" ", rotatedNumbers));

            //for (int i = 0; i < rotations; i++)
            //{
            //    int firstNumber = numbers[0];

            //    for (int j = 0; j < numbers.Length - 1; j++)
            //    {
            //        numbers[j] = numbers[j + 1];
            //    }
            //    numbers[numbers.Length - 1] = firstNumber;
            //}

            //Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
