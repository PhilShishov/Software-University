
namespace _07_EqualArrays
{
    using System;
    using System.Linq;

    class EqualArrays
    {
        static void Main()
        {
            int[] numbersArrayOne = Console
                 .ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int[] numbersArrayTwo = Console
                 .ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int sum = 0;

            for (int i = 0; i < numbersArrayOne.Length; i++)
            {
                if (numbersArrayOne[i] != numbersArrayTwo[i])
                {
                    Console.WriteLine
                        ($"Arrays are not identical. Found difference at {i} index");
                    break;
                    //return;
                }
                else
                {
                    sum += numbersArrayOne[i];
                }
                if (i == numbersArrayOne.Length - 1)
                {
                    Console.WriteLine($"Arrays are identical. Sum: {sum}");
                }
            }
            //Console.WriteLine($"Arrays are identical. Sum: {numbersArrayOne.Sum()}");
        }
    }
}
