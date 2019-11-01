using System;
using System.Collections.Generic;

namespace P02
{
    public class Program
    {
        static string[][] beach;       

        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            beach = new string[rows][];

            List<string> collectedSeashells = new List<string>();
            int stolenSeashells = 0;

            Initialize(beach);

            string line = Console.ReadLine();

            while (line != "Sunset")
            {
                string[] commandsInfo = line.Split();

                string command = commandsInfo[0];
                int row = int.Parse(commandsInfo[1]);
                int col = int.Parse(commandsInfo[2]);

                if (!IsInside(beach, row, col))
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (command == "Collect")
                {
                    if (beach[row][col] != "-")
                    {
                        collectedSeashells.Add(beach[row][col]);
                        beach[row][col] = "-";
                    }
                }

                else if (command == "Steal")
                {
                    string direction = commandsInfo[3];
                    int seagullRowCount = 0;
                    int seagullColCount = 0;

                    if (beach[row][col] == "-")
                    {
                        line = Console.ReadLine();
                        continue;
                    }

                    if (direction == "up")
                    {
                        while (IsInside(beach, row, col) && seagullRowCount <= 3)
                        {                           
                            if (beach[row][col] != "-")
                            {
                                beach[row][col] = "-";
                                stolenSeashells++;
                                seagullRowCount++;
                            }
                            row--;
                        }
                    }

                    else if (direction == "down")
                    {
                        while (IsInside(beach, row, col) && seagullRowCount <= 3)
                        {                           
                            if (beach[row][col] != "-")
                            {
                                beach[row][col] = "-";
                                stolenSeashells++;
                                seagullRowCount++;
                            }
                            row++;
                        }
                    }

                    else if (direction == "left")
                    {
                        while (IsInside(beach, row, col) && seagullColCount <= 3)
                        {                           
                            if (beach[row][col] != "-")
                            {
                                beach[row][col] = "-";
                                stolenSeashells++;
                                seagullColCount++;
                            }
                            col--;
                        }
                    }
                    else if (direction == "right")
                    {
                        while (IsInside(beach, row, col) && seagullColCount <= 3)
                        {                            
                            if (beach[row][col] != "-")
                            {
                                beach[row][col] = "-";
                                stolenSeashells++;
                                seagullColCount++;
                            }
                            col++;
                        }
                    }
                }

                line = Console.ReadLine();
            }

            End();

            if (collectedSeashells.Count == 0)
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count}");
            }

            else
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count} -> {string.Join(", ", collectedSeashells)}");
            }

            Console.WriteLine($"Stolen seashells: {stolenSeashells}");
        }

        private static bool IsInside(string[][] beach, int row, int col)
        {
            return row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length;
        }

        private static void End()
        {
            for (int row = 0; row < beach.Length; row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write(beach[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Initialize(string[][] beach)
        {
            for (int row = 0; row < beach.Length; row++)
            {
                var input = Console.ReadLine().Split();
                beach[row] = new string[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    beach[row][col] = input[col];
                }
            }
        }
    }
}
