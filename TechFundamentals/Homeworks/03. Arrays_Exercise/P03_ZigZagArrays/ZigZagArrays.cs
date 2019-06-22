﻿
namespace P03_ZigZagArrays
{
    using System;
    using System.Linq;

    class ZigZagArrays
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            int[] firstArr = new int[linesCount];
            int[] secondArr = new int[linesCount];

            for (int i = 0; i < linesCount; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    firstArr[i] = numbers[0];
                    secondArr[i] = numbers[1];
                }
                else
                {
                    firstArr[i] = numbers[1];
                    secondArr[i] = numbers[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstArr));
            Console.WriteLine(string.Join(" ", secondArr));

            //for (int i = 0; i < firstArr.Length; i++)
            //{
            //    Console.Write($"{firstArr[i]} ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < secondArr.Length; i++)
            //{
            //    Console.Write($"{secondArr[i]} ");
            //}
            //Console.WriteLine();
        }
    }
}
