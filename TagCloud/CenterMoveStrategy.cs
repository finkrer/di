using System;
using System.Drawing;

namespace TagCloud
{
    public class CenterMoveStrategy : IPlacementStrategy
    {
        public Point Center { get; }

        public CenterMoveStrategy(Point center)
        {
            Center = center;
        }

        public Rectangle PlaceRectangle(Rectangle newRectangle, Rectangle[] existingRectangles)
        {
            var stepX = 1 * Math.Sign(Center.X - newRectangle.Location.X);
            var stepY = 1 * Math.Sign(Center.Y - newRectangle.Location.Y);

            var previousLocation = newRectangle.Location;
            while (!newRectangle.HasCollisionsWith(existingRectangles) && newRectangle.X != Center.X + stepX)
            {
                previousLocation = newRectangle.Location;
                newRectangle = newRectangle.Move(stepX, 0);
            }
            newRectangle.Location = previousLocation;

            while (!newRectangle.HasCollisionsWith(existingRectangles) && newRectangle.Y != Center.Y + stepY)
            {
                previousLocation = newRectangle.Location;
                newRectangle = newRectangle.Move(0, stepY);
            }
            newRectangle.Location = previousLocation;

            return newRectangle;
        }
    }
}
