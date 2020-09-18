using System;
using System.Linq;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dim = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[dim[0], dim[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] letters = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = letters[j];
                }
            }

            int squaresMatrix = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char currentSymbol = matrix[row, col];

                    if (currentSymbol == matrix[row, col + 1]
                        && currentSymbol == matrix[row + 1, col]
                        && currentSymbol == matrix[row + 1, col + 1])
                    {
                        squaresMatrix++;
                    }
                }
            }
            Console.WriteLine(squaresMatrix);
        }
    }
}

