namespace P01.After.Contracts
{
    public interface IRenderer
    {
        void Render(IDrawingContext drawingContext, IShape shape);
    }
}
