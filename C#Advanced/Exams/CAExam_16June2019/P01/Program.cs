namespace P01
{
    using System;

    public class Program
    {
        static string[][] garden;

        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            garden = new string[rows][];

            int countOfCarrots = 0;
            int countOfPotatoes = 0;
            int countOfCucumbers = 0;
            int harmedVegetables = 0;

            Initialize(garden);

            string line = Console.ReadLine();

            while (line != "End of Harvest")
            {
                string[] commandsInfo = line.Split();

                string command = commandsInfo[0];
                int row = int.Parse(commandsInfo[1]);
                int col = int.Parse(commandsInfo[2]);

                if (!IsInside(garden, row, col))
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (command == "Harvest")
                {
                    if (garden[row][col] != " ")
                    {
                        if (garden[row][col] == "L")
                        {
                            countOfCucumbers++;
                        }

                        else if (garden[row][col] == "P")
                        {
                            countOfPotatoes++;
                        }

                        else if (garden[row][col] == "C")
                        {
                            countOfCarrots++;
                        }

                        garden[row][col] = " ";
                    }
                }

                else if (command == "Mole")
                {
                    string direction = commandsInfo[3];
                    if (direction == "right")
                    {
                        while (IsInside(garden, row, col))
                        {
                            if (garden[row][col] != " ")
                            {
                                garden[row][col] = " ";
                                harmedVegetables++;
                            }
                            col += 2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (IsInside(garden, row, col))
                        {
                            if (garden[row][col] != " ")
                            {
                                garden[row][col] = " ";
                                harmedVegetables++;
                            }
                            col -= 2;
                        }
                    }

                    else if (direction == "up")
                    {
                        while (IsInside(garden, row, col))
                        {
                            if (garden[row][col] != " ")
                            {
                                garden[row][col] = " ";
                                harmedVegetables++;
                            }
                            row -= 2;
                        }
                    }

                    else if (direction == "down")
                    {
                        while (IsInside(garden, row, col))
                        {
                            if (garden[row][col] != " ")
                            {
                                garden[row][col] = " ";
                                harmedVegetables++;
                            }
                            row += 2;
                        }
                    }
                }

                line = Console.ReadLine();
            }

            End();

            Console.WriteLine($"Carrots: {countOfCarrots}");
            Console.WriteLine($"Potatoes: {countOfPotatoes}");
            Console.WriteLine($"Lettuce: {countOfCucumbers}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }

        private static void End()
        {
            for (int row = 0; row < garden.Length; row++)
            {
                for (int col = 0; col < garden[row].Length; col++)
                {
                    Console.Write(garden[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(string[][] garden, int row, int col)
        {
            return row >= 0 && row < garden.Length && col >= 0 && col < garden[row].Length;
        }

        private static void Initialize(string[][] garden)
        {
            for (int row = 0; row < garden.Length; row++)
            {
                var input = Console.ReadLine().Split();
                garden[row] = new string[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    garden[row][col] = input[col];
                }
            }
        }
    }
}
