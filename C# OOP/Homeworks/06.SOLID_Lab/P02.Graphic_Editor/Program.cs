using System;

namespace P02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            var circle = new Circle();
            var rec = new Rectangle();
            var sqr = new Square();

            var drawer = new GraphicEditor();

            drawer.Draw(circle);
            drawer.Draw(rec);
            drawer.Draw(sqr);
        }
    }
}
