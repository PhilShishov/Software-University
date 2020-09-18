using System;
using System.Linq;

namespace P07
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            int[] indexes = new int[]
            {
                1, 2,
                1,-2,
               -1, 2,
               -1,-2,
                2, 1,
                2,-1,
               -2, 1,
               -2,-1
            };

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxCount = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int currentCount = 0;

                        if (board[row, col] == 'K')
                        {
                            for (int i = 0; i < indexes.Length; i += 2)
                            {
                                if (IsInside(board, row + indexes[i], col + indexes[i + 1]) 
                                    && board[row + indexes[i], col + indexes[i + 1]] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0 &&
                desiredCol < board.GetLength(1) && desiredCol >= 0;
        }
    }
}