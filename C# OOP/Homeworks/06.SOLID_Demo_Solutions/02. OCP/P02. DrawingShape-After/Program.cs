using System;

namespace P02._DrawingShape_After
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle();
            var circle1 = new Circle();
            var circle2 = new Circle();

            var rec = new Rectangle();
            var rec1 = new Rectangle();
            var rec2 = new Rectangle();

            var drawer = new CircleDrawer();

            //var drawer = new DrawingManager();

            //drawer.Draw(circle);
            //drawer.Draw(rec);
            //drawer.Draw(circle1);
            //drawer.Draw(rec1);
            //drawer.Draw(circle2);
        }
    }
}
