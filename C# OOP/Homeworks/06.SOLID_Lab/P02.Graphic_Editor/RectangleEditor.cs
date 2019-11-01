namespace P02.Graphic_Editor
{
    using P02.Graphic_Editor.Contracts;
    using System;


    public class RectangleEditor : IGraphicEditor
    {
        public void Draw(IShape shape)
        {
            var circle = shape as Rectangle;
            Console.WriteLine("I'm Recangle");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Rectangle)
            {
                return true;
            }

            return false;
        }
    }
}
