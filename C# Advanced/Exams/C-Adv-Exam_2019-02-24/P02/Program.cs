
namespace P02
{
    using System;

    class Program
    {
        static char[][] tronField;

        static int firstPlayerRow;
        static int firstPlayerCol;

        static int secondPlayerRow;
        static int secondPlayerCol;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            tronField = new char[rows][];

            Initialize(tronField);

            while (true)
            {
                var commands = Console.ReadLine().Split();

                string commandFirstPlayer = commands[0];
                string commandSecondPlayer = commands[1];

                MoveFirstPlayer(commandFirstPlayer);

                MoveSecondPlayer(commandSecondPlayer);

                if (tronField[firstPlayerRow][firstPlayerCol] == 's')
                {
                    tronField[firstPlayerRow][firstPlayerCol] = 'x';
                    End();
                }
                else
                {
                    tronField[firstPlayerRow][firstPlayerCol] = 'f';
                }

                if (tronField[secondPlayerRow][secondPlayerCol] == 'f')
                {
                    tronField[secondPlayerRow][secondPlayerCol] = 'x';
                    End();
                }
                else
                {
                    tronField[secondPlayerRow][secondPlayerCol] = 's';
                }
            }
        }

        private static void MoveSecondPlayer(string commandSecondPlayer)
        {
            if (commandSecondPlayer == "up")
            {
                secondPlayerRow--;

                if (secondPlayerRow < 0)
                {
                    secondPlayerRow = tronField.Length - 1;
                }
            }
            else if (commandSecondPlayer == "down")
            {
                secondPlayerRow++;

                if (secondPlayerRow > tronField.Length - 1)
                {
                    secondPlayerRow = 0;
                }
            }
            else if (commandSecondPlayer == "left")
            {
                secondPlayerCol--;

                if (secondPlayerCol < 0)
                {
                    secondPlayerCol = tronField[secondPlayerRow].Length - 1;
                }
            }
            else if (commandSecondPlayer == "right")
            {
                secondPlayerCol++;

                if (secondPlayerCol > tronField[secondPlayerRow].Length - 1)
                {
                    secondPlayerCol = 0;
                }
            }
        }

        private static void MoveFirstPlayer(string commandFirstPlayer)
        {
            if (commandFirstPlayer == "up")
            {
                firstPlayerRow--;

                if (firstPlayerRow < 0)
                {
                    firstPlayerRow = tronField.Length - 1;
                }
            }
            else if (commandFirstPlayer == "down")
            {
                firstPlayerRow++;

                if (firstPlayerRow > tronField.Length - 1)
                {
                    firstPlayerRow = 0;
                }
            }
            else if (commandFirstPlayer == "left")
            {
                firstPlayerCol--;

                if (firstPlayerCol < 0)
                {
                    firstPlayerCol = tronField[firstPlayerRow].Length - 1;
                }
            }
            else if (commandFirstPlayer == "right")
            {
                firstPlayerCol++;

                if (firstPlayerCol > tronField[firstPlayerRow].Length - 1)
                {
                    firstPlayerCol = 0;
                }
            }
        }

        private static void End()
        {
            for (int row = 0; row < tronField.Length; row++)
            {
                for (int col = 0; col < tronField[row].Length; col++)
                {
                    Console.Write(tronField[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void Initialize(char[][] tronField)
        {
            for (int row = 0; row < tronField.Length; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                tronField[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    tronField[row][col] = input[col];

                    if (tronField[row][col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    if (tronField[row][col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }

                }
            }
        }
    }
}

