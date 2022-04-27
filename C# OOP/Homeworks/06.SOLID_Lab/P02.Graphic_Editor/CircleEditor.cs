namespace P02.Graphic_Editor
{
    using System;

    using P02.Graphic_Editor.Contracts;

    public class CircleEditor : IGraphicEditor
    {
        public void Draw(IShape shape)
        {
            var circle = shape as Circle;
            Console.WriteLine("I'm Circle");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Circle)
            {
                return true;
            }

            return false;
        }
    }
}
