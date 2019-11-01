namespace P06_Sneaking
{
    using System;
    using System.Linq;

    public class Board
    {
        private char[][] jaggedArray;

        public Board(int size)
        {
            this.jaggedArray = new char[size][];
            this.FillMatrix();
        }

        public void FillMatrix()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().ToCharArray();
            }
        }
        public int[] FindPlayer()
        {
            int[] player = new int[2];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'S')
                    {
                        player[0] = row;
                        player[1] = col;
                    }
                }
            }
            return player;
        }
        public void EnamiesMoving()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'b')
                    {
                        if (col == jaggedArray[row].Length - 1)
                        {
                            jaggedArray[row][col] = 'd';
                        }
                        else
                        {
                            jaggedArray[row][col] = '.';
                            jaggedArray[row][++col] = 'b';
                        }
                    }
                    else if (jaggedArray[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            jaggedArray[row][col] = 'b';
                        }
                        else
                        {
                            jaggedArray[row][col] = '.';
                            jaggedArray[row][--col] = 'd';
                        }
                    }
                }
            }
        }
        public void CheckEnemiesAndSam()
        {
            int colSam;
            int colEnemy;
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                if (jaggedArray[row].Contains('b') && jaggedArray[row].Contains('S'))
                {
                    colSam = Array.IndexOf(jaggedArray[row], 'S');
                    colEnemy = Array.IndexOf(jaggedArray[row], 'b');
                    if (colSam > colEnemy)
                    {
                        jaggedArray[row][colSam] = 'X';
                        Console.WriteLine($"Sam died at {row}, {colSam}");
                        PrintMatrix();
                    }
                }
                if (jaggedArray[row].Contains('d') && jaggedArray[row].Contains('S'))
                {
                    colSam = Array.IndexOf(jaggedArray[row], 'S');
                    colEnemy = Array.IndexOf(jaggedArray[row], 'd');
                    if (colSam < colEnemy)
                    {
                        jaggedArray[row][colSam] = 'X';
                        Console.WriteLine($"Sam died at {row}, {colSam}");
                        PrintMatrix();
                    }
                }
            }
        }
        public void MoveSam(char command, Player player)
        {
            switch (command)
            {
                case 'U':
                    jaggedArray[player.Row][player.Col] = '.';
                    jaggedArray[--player.Row][player.Col] = 'S';

                    break;
                case 'D':
                    jaggedArray[player.Row][player.Col] = '.';
                    jaggedArray[++player.Row][player.Col] = 'S';
                    break;
                case 'L':
                    jaggedArray[player.Row][player.Col] = '.';
                    jaggedArray[player.Row][--player.Col] = 'S';
                    break;
                case 'R':
                    jaggedArray[player.Row][player.Col] = '.';
                    jaggedArray[player.Row][++player.Col] = 'S';
                    break;
                default:
                    break;
            }
        }
        public void CheckNikoladze()
        {
            int colNikoladze;
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                if (jaggedArray[row].Contains('N') && jaggedArray[row].Contains('S'))
                {
                    colNikoladze = Array.IndexOf(jaggedArray[row], 'N');
                    jaggedArray[row][colNikoladze] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    PrintMatrix();
                }
            }
        }
        public void PrintMatrix()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join("", jaggedArray[row]));
            }
            Environment.Exit(0);
        }
    }
}
