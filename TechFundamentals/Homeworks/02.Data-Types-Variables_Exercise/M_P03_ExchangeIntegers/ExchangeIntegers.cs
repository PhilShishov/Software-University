
namespace M_P03_ExchangeIntegers
{
    using System;

    class ExchangeIntegers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int aOld = a;
            int bOld = b;
            a = b;
            b = aOld;

            Console.WriteLine("Before:");
            Console.WriteLine($"a = {aOld}");
            Console.WriteLine($"b = {bOld}");
            Console.WriteLine("After:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }
    }
}
