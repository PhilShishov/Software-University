using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var radius = int.Parse(Console.ReadLine());
            Circle circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            Rectangle rect = new Rectangle(width, height);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rect.Draw());
        }
    }
}
