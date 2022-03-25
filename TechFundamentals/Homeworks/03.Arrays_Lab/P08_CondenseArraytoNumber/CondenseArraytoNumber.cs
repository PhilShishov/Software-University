
namespace P08_CondenseArraytoNumber
{
    using System;
    using System.Linq;

    class CondenseArraytoNumber
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (numbers.Length > 1)
            {
                int[] condensed = new int[numbers.Length - 1];
                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = numbers[i] + numbers[i + 1];
                }
                numbers = condensed;
            }
           Console.WriteLine(numbers[0]);


        }
    }
}
