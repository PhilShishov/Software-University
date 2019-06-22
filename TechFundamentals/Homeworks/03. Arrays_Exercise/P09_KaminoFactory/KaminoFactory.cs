
namespace P09_KaminoFactory
{
    using System;
    using System.Linq;

    class KaminoFactory
    {
        static void Main()
        {
            int DNALenght = int.Parse(Console.ReadLine());

            int length = 0;
            int sum = 0;
            int startIndex = -1;
            int row = 0;
            int currentRow = 1;

            int[] DNA = new int[DNALenght];

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Clone them!")
                {
                    break;
                }

                int[] currentDNA = line
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentSum = 0;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {
                        currentSum += 1;
                    }
                }

                if (currentRow == 1)
                {
                    DNA = currentDNA;
                    row = currentRow;
                    sum = currentSum;
                }

                int currentStartIndex = -1;
                int currentLenght = 0;
                bool isFound = false;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] == 1)
                    {
                        if (!isFound)
                        {
                            currentStartIndex = i;
                        }

                        currentLenght++;

                        if (currentLenght > length)
                        {
                            length = currentLenght;
                            startIndex = currentStartIndex;
                            sum = currentSum;
                            row = currentRow;

                            DNA = currentDNA;
                        }
                        else if (currentLenght == length)
                        {
                            if (currentStartIndex < startIndex)
                            {
                                length = currentLenght;
                                startIndex = currentStartIndex;
                                sum = currentSum;
                                row = currentRow;

                                DNA = currentDNA;
                            }
                            else if (currentSum > sum)
                            {
                                length = currentLenght;
                                startIndex = currentStartIndex;
                                sum = currentSum;
                                row = currentRow;

                                DNA = currentDNA;
                            }
                        }
                    }
                    else
                    {
                        currentStartIndex = -1;
                        currentLenght = 0;
                        isFound = false;
                    }
                }
                currentRow++;
            }

            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
