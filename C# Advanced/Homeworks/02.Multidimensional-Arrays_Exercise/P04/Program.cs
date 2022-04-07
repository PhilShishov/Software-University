
namespace P04
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

            int[,] matrix = new int[dim[0], dim[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);

                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);

                if (command != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
