using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagCloud
{
    public class RectangleVisualizer
    {
        public IEnumerable<Size> Rectangles { get; }
        public ICloudLayouter Layouter { get; }
        public ICloudVisualizer Visualizer { get; }

        public RectangleVisualizer(IEnumerable<Size> rectangles,
            ICloudLayouter layouter, ICloudVisualizer visualizer)
        {
            Rectangles = rectangles;
            Layouter = layouter;
            Visualizer = visualizer;
        }

        public void CreateCloudImage(string path)
        {
            foreach (var rectangle in Rectangles)
                Layouter.PutNextRectangle(rectangle);

            Visualizer.CreateImage(Layouter.Rectangles, path);
        }
    }
}
