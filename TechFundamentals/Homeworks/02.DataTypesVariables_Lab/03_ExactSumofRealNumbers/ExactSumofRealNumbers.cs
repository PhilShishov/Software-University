
namespace _03_ExactSumofRealNumbers
{
    using System;

    class ExactSumofRealNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0m;

            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
