using System.Drawing;

namespace TagCloud
{
    public static class RectangleExtensions
    {
        public static Rectangle Move(this Rectangle rectangle, int x, int y)
        {
            rectangle.Location = new Point(rectangle.X + x, rectangle.Y + y);
            return rectangle;
        }
    }
}
