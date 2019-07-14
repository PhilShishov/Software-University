
namespace P13_RecursiveFibonacci
{
    using System;

    class RecursiveFibonacci
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long[] fibonacci = new long[n];

            if (n == 1 || n == 2)
            {
                Console.WriteLine(1);
            }
            else if (n > 2 && n <= 50)
            {
                fibonacci[0] = 1;
                fibonacci[1] = 1;

                for (long i = 2; i < fibonacci.Length; i++)
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                    if (i == n - 1)
                    {
                        Console.WriteLine(fibonacci[i]);
                    }
                }
            }
        }
    }
}
