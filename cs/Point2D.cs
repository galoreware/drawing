using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galoreware.Drawing
{
    public class Point2D
    {
        int _x, _y;

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }

        public Point2D()
        {
            _x = 0;
            _y = 0;
        }

        public Point2D(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Point2D Rotate(float angle)
        {
            Point2D p = new Point2D(_x, _y);

            float alpha = (float)(angle * Math.PI) / 180.0f;

            double sinAlpha = Math.Sin(alpha);
            double cosAlpha = Math.Cos(alpha);

            p.X = (int)(_x * cosAlpha - _y * sinAlpha);
            p.Y = (int)(_x * sinAlpha + _y * cosAlpha);

            return p;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }

        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }

        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D(a.X - b.X, a.Y - b.Y);
        }
    }
}
