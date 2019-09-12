namespace P02.Graphic_Editor
{
    using P02.Graphic_Editor.Contracts;
    using System;


    public class SquareEditor : IGraphicEditor
    {
        public void Draw(IShape shape)
        {
            var circle = shape as Square;
            Console.WriteLine("I'm Square");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Square)
            {
                return true;
            }

            return false;
        }
    }
}
