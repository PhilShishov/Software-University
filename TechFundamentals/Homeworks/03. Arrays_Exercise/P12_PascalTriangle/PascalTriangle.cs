
namespace P12_PascalTriangle
{
    using System;

    class PascalTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            if (n >= 1 && n <= 60)
            {
                for (int row = 0; row < n; row++)
                {
                    int pascalTriangle = 1;
                    for (int col = 0; col <= row; col++)
                    {
                        if (col == row)
                        {
                            Console.Write($"{pascalTriangle:D}");
                            break;
                        }
                        Console.Write($"{pascalTriangle:D} ");
                        pascalTriangle = pascalTriangle * (row - col) / (col + 1);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
