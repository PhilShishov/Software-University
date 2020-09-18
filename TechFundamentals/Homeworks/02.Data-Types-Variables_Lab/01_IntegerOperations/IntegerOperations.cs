
namespace _01_IntegerOperations
{
    using System;

    class IntegerOperations
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int o = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int result = (n + m) / o * p;

            Console.WriteLine(result);
        }
    }
}
