using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagCloud
{
    public class SpiralStrategy : IPlacementStrategy
    {
        public Point Center { get; }

        public SpiralStrategy(Point center)
        {
            Center = center;
        }

        public Rectangle PlaceRectangle(Rectangle newRectangle, Rectangle[] existingRectangles)
        {
            for (var step = 1; newRectangle.HasCollisionsWith(existingRectangles); step++)
            {
                var x = step * Math.Cos(step);
                var y = step * Math.Sin(step);
                newRectangle.Location = new Point((int)x + Center.X, (int)y + Center.Y);
            }

            return newRectangle;
        }
    }
}
