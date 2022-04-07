
namespace P05
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] dim = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[dim[0], dim[1]];
            string snake = Console.ReadLine();
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (counter >= snake.Length)
                    {
                        counter = 0;
                    }

                    matrix[row, col] = snake[counter++];
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
