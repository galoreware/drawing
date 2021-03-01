using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Galoreware.Drawing
{
    public class Area
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }

        public Point2D Center { get; set; }

        public Area()
        {

        }

        public Area(IEnumerable<Point> points)
        {
            Top = points.Min(p => p.Y);
            Bottom = points.Max(p => p.Y);
            Left = points.Min(p => p.X);
            Right = points.Max(p => p.X);

            Width = Right - Left;
            Height = Bottom - Top;

            Center = new Point2D(Left, Top);
        }
    }
}
