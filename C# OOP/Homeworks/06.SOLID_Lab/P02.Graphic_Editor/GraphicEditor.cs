
namespace P02.Graphic_Editor
{
    using System.Linq;
    using System.Collections.Generic;
    
    using P02.Graphic_Editor.Contracts;

    public class GraphicEditor
    {
        public void Draw(IShape shape)
        {
            var drawers = new List<IGraphicEditor>()
            {
                new CircleEditor(),
                new RectangleEditor(),
                new SquareEditor()
            };

            drawers.First(d => d.IsMatch(shape)).Draw(shape);
        }
    }
}
