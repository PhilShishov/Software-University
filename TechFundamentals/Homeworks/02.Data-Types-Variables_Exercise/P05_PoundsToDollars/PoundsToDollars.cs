
namespace P05_PoundsToDollars
{
    using System;

    class PoundsToDollars
    {
        static void Main(string[] args)
        {
            decimal pound = decimal.Parse(Console.ReadLine());

            decimal dollar = pound * 1.31m;

            //Console.WriteLine($"{dollar:F3}");
            Console.WriteLine(dollar.ToString("F3"));
        }
    }
}
