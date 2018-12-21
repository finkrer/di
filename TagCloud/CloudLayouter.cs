using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagCloud
{
    public class CloudLayouter : ICloudLayouter
    {
        private readonly IEnumerable<IPlacementStrategy> strategies;
        public Point Center { get; }
        public List<Rectangle> Rectangles { get; } = new List<Rectangle>();

        public CloudLayouter(IEnumerable<IPlacementStrategy> strategies)
        {
            this.strategies = strategies;
            Center = new Point();
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width <= 0 || rectangleSize.Height <= 0)
                throw new ArgumentException("Rectangle dimensions must be positive");
            var rectangle = new Rectangle(Center, rectangleSize);
            rectangle = strategies.Aggregate(rectangle,
                (current, strategy) => strategy.PlaceRectangle(current, Rectangles.ToArray()));
            Rectangles.Add(rectangle);
            return rectangle;
        }
    }
}
