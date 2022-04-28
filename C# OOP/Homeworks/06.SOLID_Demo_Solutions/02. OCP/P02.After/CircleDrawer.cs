namespace P02.After
{
    using Contracts;

    public class CircleDrawer : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var circle = shape as Circle;

            // Draw Circle
        }

        //public bool IsMatch(IShape shape)
        //{
        //    if (shape is Circle)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
