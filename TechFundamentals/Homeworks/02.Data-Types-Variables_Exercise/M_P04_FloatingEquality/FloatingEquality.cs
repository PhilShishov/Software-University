
namespace M_P04_FloatingEquality
{
    using System;

    class FloatingEquality
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double eps = 0.000001;
            bool areNumsDifferent = false;

            double difference = Math.Abs(a - b);

            areNumsDifferent = difference < eps;
            Console.WriteLine(areNumsDifferent);
        }
    }
}
