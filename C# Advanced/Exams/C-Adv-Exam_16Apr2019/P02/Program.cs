
namespace P02_HelensAbduction
{
    using System;

    class Program
    {
        static char[][] spartaField;

        static int parisRow;
        static int parisCol;

        static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            spartaField = new char[rows][];

            Initialize(spartaField);

            while (energy > 0)
            {
                var commandInfo = Console.ReadLine().Split();

                string command = commandInfo[0];
                int spartanRow = int.Parse(commandInfo[1]);
                int spartanCol = int.Parse(commandInfo[2]);

                spartaField[spartanRow][spartanCol] = 'S';
                spartaField[parisRow][parisCol] = '-';

                if (command == "up")
                {
                    parisRow--;
                    energy--;
                    if (parisRow < 0)
                    {
                        parisRow = 0;
                    }
                }

                else if (command == "down")
                {
                    parisRow++;
                    energy--;
                    if (parisRow > spartaField.Length - 1)
                    {
                        parisRow = spartaField.Length - 1;
                    }
                }

                else if (command == "left")
                {
                    parisCol--;
                    energy--;
                    if (parisCol < 0)
                    {
                        parisCol = 0;
                    }
                }

                else if (command == "right")
                {
                    parisCol++;
                    energy--;
                    if (parisCol > spartaField[parisRow].Length - 1)
                    {
                        parisCol = spartaField[parisRow].Length - 1;
                    }
                }

                if (spartaField[parisRow][parisCol] == 'H')
                {
                    spartaField[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    End();
                }

                else if (spartaField[parisRow][parisCol] == 'S')
                {
                    energy -= 2;
                    spartaField[parisRow][parisCol] = '-';
                }

                if (energy <= 0)
                {
                    spartaField[parisRow][parisCol] = 'X';
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    End();
                }
            }
        }

        private static void End()
        {
            for (int row = 0; row < spartaField.Length; row++)
            {
                for (int col = 0; col < spartaField[row].Length; col++)
                {
                    Console.Write(spartaField[row][col]);
                }
                Console.WriteLine();
            }

            Environment.Exit(0);
        }

        private static void Initialize(char[][] spartaField)
        {
            for (int row = 0; row < spartaField.Length; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                spartaField[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    spartaField[row][col] = input[col];

                    if (spartaField[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }
        }
    }
}
