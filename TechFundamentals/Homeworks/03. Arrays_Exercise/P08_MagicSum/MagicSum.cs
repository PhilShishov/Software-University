
namespace P08_MagicSum
{
    using System;
    using System.Linq;

    class MagicSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int magicSum = int.Parse(Console.ReadLine());
            int[] magicNumbers = new int[2];

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int secondNum = numbers[j];
                    if (num + secondNum == magicSum)
                    {
                        magicNumbers[0] = num;
                        magicNumbers[1] = secondNum;
                        Console.WriteLine(string.Join(" ", magicNumbers));
                    }
                }
            }


        }
    }
}
