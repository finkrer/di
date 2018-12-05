using System.Collections.Generic;
using System.Drawing;

namespace TagCloud
{
    public interface ICloudLayouter
    {
        Point Center { get; }
        List<Rectangle> Rectangles { get; }
        Rectangle PutNextRectangle(Size rectangleSize);
    }
}