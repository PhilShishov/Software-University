
namespace _02_CircleArea
{
    using System;

    class CircleArea
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double areaCircle = r * r * Math.PI;
            Console.WriteLine($"{areaCircle:F12}");
        }
    }
}
