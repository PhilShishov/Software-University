
namespace P05_BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BombNumbers
    {
        static void Main()
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bombProp = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bomb = bombProp[0];
            int power = bombProp[1];

            for (int i = 0; i < sequence.Count; i++)
            {
                int currentNumber = sequence[i];

                if (currentNumber == bomb)
                {
                    int startIndex = i - power;
                    int endIndex = i + power;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex > sequence.Count - 1)
                    {
                        endIndex = sequence.Count - 1;
                    }

                    if (startIndex > sequence.Count - 1 || endIndex < 0)
                    {
                        continue;
                    }

                    sequence.RemoveRange(startIndex, endIndex - startIndex + 1);

                    i = startIndex - 1;
                }
            }

            int sum = sequence.Sum();

            Console.WriteLine(sum);
        }
    }
}
