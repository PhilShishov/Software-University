namespace P03
{
    using System;

    class Program
    {
        static char[][] galaxy;

        static int stephenRow;
        static int stephenCol;

        static int blackHoleExitRow;
        static int blackHoleExitCol;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            galaxy = new char[size][];

            Initialize(galaxy);

            int starPower = 0;

            while (starPower < 50)
            {
                var command = Console.ReadLine();

                galaxy[stephenRow][stephenCol] = '-';

                if (command == "right")
                {
                    stephenCol++;
                }

                else if (command == "left")
                {
                    stephenCol--;
                }

                else if (command == "down")
                {
                    stephenRow++;
                }

                else if (command == "up")
                {
                    stephenRow--;
                }

                if (!IsInside(galaxy, stephenRow, stephenCol))
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Console.WriteLine($"Star power collected: {starPower}");
                    End();
                }

                if (galaxy[stephenRow][stephenCol] == 'O')
                {
                    galaxy[stephenRow][stephenCol] = '-';
                    stephenRow = blackHoleExitRow;
                    stephenCol = blackHoleExitCol;
                }

                else if (Char.IsDigit(galaxy[stephenRow][stephenCol]))
                {
                    starPower += (int)Char.GetNumericValue(galaxy[stephenRow][stephenCol]);
                }
            }

            galaxy[stephenRow][stephenCol] = 'S';

            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {starPower}");
            End();
        }

        private static void End()
        {
            for (int row = 0; row < galaxy.Length; row++)
            {
                for (int col = 0; col < galaxy[row].Length; col++)
                {
                    Console.Write(galaxy[row][col]);
                }
                Console.WriteLine();
            }

            Environment.Exit(0);
        }

        private static bool IsInside(char[][] galaxy, int row, int col)
        {
            return row >= 0 && row < galaxy.Length && col >= 0 && col < galaxy[row].Length;
        }

        private static void Initialize(char[][] galaxy)
        {
            int blackHoleCount = 0;

            for (int row = 0; row < galaxy.Length; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                galaxy[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    galaxy[row][col] = input[col];

                    if (galaxy[row][col] == 'S')
                    {
                        stephenRow = row;
                        stephenCol = col;
                    }
                    if (galaxy[row][col] == 'O')
                    {
                        blackHoleCount++;
                    }

                    if (galaxy[row][col] == 'O' && blackHoleCount == 2)
                    {
                        blackHoleExitRow = row;
                        blackHoleExitCol = col;
                    }
                }
            }
        }
    }
}
