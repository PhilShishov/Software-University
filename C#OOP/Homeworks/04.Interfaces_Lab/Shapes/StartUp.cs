using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);

            var shapes = new List<IDrawable>
            {
                circle,
                rect
            };  

            DrawAllShapes(shapes);
        }

        private static void DrawAllShapes(IEnumerable<IDrawable> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
