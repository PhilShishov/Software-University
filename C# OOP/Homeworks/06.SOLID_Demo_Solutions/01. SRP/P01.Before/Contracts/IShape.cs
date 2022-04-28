namespace P01.Before.Contracts
{
    public interface IShape
    {
        void Draw(IRenderer renderer, IDrawingContext drawingContext);
    }
}