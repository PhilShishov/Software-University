namespace P02._DrawingShape_After
{
    using Contracts;

    public class RectangleDrawer : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var rectangle = shape as Rectangle;

            // Draw Rectangle
        }
        //public bool IsMatch(IShape shape)
        //{
        //    if (shape is Rectangle)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

    }
}
