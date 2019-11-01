namespace P02.Graphic_Editor.Contracts
{
    public interface IGraphicEditor
    {
        void Draw(IShape shape);

        bool IsMatch(IShape shape);
    }
}