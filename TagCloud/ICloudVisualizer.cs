using System.Collections.Generic;
using System.Drawing;

namespace TagCloud
{
    public interface ICloudVisualizer
    {
        Bitmap CreateImage(IEnumerable<Rectangle> rectangles, string path);
    }
}