
namespace P13_CenterPoint
{
    using System;

    class CenterPoint
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double firstPairResult = Math.Abs(x1) + Math.Abs(y1);
            double secondPairResult = Math.Abs(x2) + Math.Abs(y2);
            PrintResult(firstPairResult, secondPairResult, x1, y1, x2, y2);
        }

        private static void PrintResult(double firstPairResult, double secondPairResult, double x1, double y1, double x2, double y2)
        {
            if (firstPairResult <= secondPairResult)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (firstPairResult > secondPairResult)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

    }
}
