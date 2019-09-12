namespace P02._DrawingShape_After
{
    using Contracts;

    public abstract class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            this.DrawFigure(shape);
        }  

        protected abstract void DrawFigure(IShape shape);


        //public class DrawingManager
        //{
        //    public void Draw(IShape shape)
        //    {
        //        var drawers = new List<IDrawingManager>()
        //    {
        //        new CircleDrawer(),
        //        new RectangleDrawer()
        //    };

        //        drawers.First(d => d.IsMatch(shape)).Draw(shape);
        //    }
        //}
    }
}
