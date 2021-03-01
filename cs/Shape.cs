using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Galoreware.Drawing
{
    public class Shape
    {
        List<Point2D> _points;

        public List<Point2D> Points { get { return _points; } set { _points = value; } }

        public Shape(IEnumerable<Point2D> points)
        {
            _points = points.ToList();
        }

        public Shape Rotate(float alpha)
        {
            Shape tmp = new Shape(Points);
            
            for (int i = 0; i < tmp.Points.Count; i++)
            {
                tmp.Points[i] = _points[i].Rotate(alpha);
            }

            return tmp;
        }

        public Point[] Translate(Point2D origin)
        {
            Point[] points = new Point[_points.Count];

            Point2D position;

            for (int i = 0; i < _points.Count; i++)
            {
                position = origin - _points[i];
                points[i] = new Point(position.X, position.Y);
            }

            return points;
        }

        public void DrawBorder(Graphics g, Point2D position, Pen border)
        {
            Point[] p = Translate(position);
            Area a = new Area(p);

            Pen dashed = new Pen(Color.Red);
            dashed.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            //g.DrawRectangle(dashed, a.Left, a.Top, a.Width, a.Height);

            g.DrawPolygon(border, p);

            foreach (Point point in p)
            {
                g.DrawString(string.Format("[{0},{1}]", point.X, point.Y), SystemFonts.DefaultFont, Brushes.Black, point);
            }

            //g.DrawLine(Pens.Red, a.Left, position.Y, a.Right, position.Y);
            //g.DrawLine(Pens.Blue, position.X, a.Top, position.X, a.Bottom);
        }

        public void DrawFill(Graphics g, Point2D position, Brush fill)
        {
            Point[] p = Translate(position);
            Area a = new Area(p);
            

            g.FillPolygon(fill, p);
        }

    }
}
