
namespace P03_BakingFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BakingFactory
    {
        static void Main()
        {
            var resultBatch = new List<int>();

            string input = Console.ReadLine();

            int sumBatch = 0;
            int bestSumBatch = int.MinValue;

            while (input != "Bake It!")
            {
                var currentBatch = input
                    .Split("#")
                    .Select(int.Parse)
                    .ToList();

                sumBatch = currentBatch.Sum();

                if (sumBatch > bestSumBatch)
                {
                    bestSumBatch = sumBatch;
                    resultBatch = currentBatch;
                }

                else if (sumBatch == bestSumBatch)
                {
                    if ((sumBatch / currentBatch.Count) > (sumBatch / resultBatch.Count))
                    {
                        resultBatch = currentBatch;
                    }
                    else if ((sumBatch / currentBatch.Count == sumBatch / resultBatch.Count)
                        && currentBatch.Count < resultBatch.Count)
                    {
                        resultBatch = currentBatch;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best Batch quality: {bestSumBatch}");
            Console.WriteLine(string.Join(" ", resultBatch));
        }
    }
}
