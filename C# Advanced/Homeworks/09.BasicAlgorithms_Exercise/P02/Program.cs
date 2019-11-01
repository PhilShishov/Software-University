using System;
using System.Numerics;

namespace P02
{
    class Program
    {
        private static BigInteger[] cache;
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            cache = new BigInteger[num + 1];

            Console.WriteLine(Fibonacci(num));
        }

        private static BigInteger Fibonacci(int n)
        {
            if (cache[n] != 0)
            {
                return cache[n];
            }

            if (n == 1 || n== 2)
            {
                return 1;
            }
            var result = Fibonacci(n - 1) + Fibonacci(n - 2);
            cache[n] = result;

            return result;
        }

        private static BigInteger Factorial(int num)
        {
            if (num < 0)
            {
                throw new InvalidOperationException();
            }

            if (num == 0)
            {
                return 1;
            }

            return num * Factorial(num - 1);
        }
    }
}
