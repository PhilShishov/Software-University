using P02.Graphic_Editor.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace P02.Graphic_Editor
{
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
