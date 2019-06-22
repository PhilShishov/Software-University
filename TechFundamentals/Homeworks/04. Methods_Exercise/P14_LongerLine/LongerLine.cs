
namespace P14_LongerLine
{
    using System;

    class LongerLine
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());

            Console.WriteLine(GetLineLength(x1, y1, x2, y2) >= GetLineLength(X1, Y1, X2, Y2)
                ? GetClosestToCenterPoint(x1, y1, x2, y2)
                : GetClosestToCenterPoint(X1, Y1, X2, Y2));
        }

        static double GetLineLength(double x1, double y1, double x2, double y2)
            => Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));


        static string GetClosestToCenterPoint(double x1, double y1, double x2, double y2)
            => Math.Abs(Math.Min(x1, y1)) <= Math.Abs(Math.Min(x2, y2))
                ? $"({x1}, {y1})({x2}, {y2})"
                : $"({x2}, {y2})({x1}, {y1})";
    }
}

