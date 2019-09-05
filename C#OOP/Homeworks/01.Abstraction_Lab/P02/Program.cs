using System;
using System.Linq;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinates = ParseInput();

            Point topLeft = new Point(coordinates[0], coordinates[1]);
            Point bottomRight = new Point(coordinates[2], coordinates[3]);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var points = ParseInput();
                Point pointToCheck = new Point(points[0], points[1]);

                Console.WriteLine(rectangle.Contains(pointToCheck));
            }
        }

        private static int[] ParseInput()
        {
           return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
