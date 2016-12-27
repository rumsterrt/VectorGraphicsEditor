using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public class Circle : Ellipse
    {
        public Circle(Canvas canvas, PointF point1, float width, Color color, Color fillColor, DashStyle dashStyle = DashStyle.Solid) :
            base(canvas, point1, width, color, fillColor, dashStyle)
        {
            ActivateMarkers(true);
        }

        public Circle(Circle other) :
            base(other)
        {
        }

        public override RectangleF GetRect()
        {
            if (_isAdded)
                return base.GetRect();
            float radius = Math.Min(Math.Abs(_points[1].Position.X - _points[0].Position.X), Math.Abs(_points[1].Position.Y - _points[0].Position.Y));
            float widthSign = Math.Sign(_points[1].Position.X - _points[0].Position.X);
            float heightSign = Math.Sign(_points[1].Position.Y - _points[0].Position.Y);
            _points[1].Position = new PointF(_points[0].Position.X + widthSign * radius, _points[0].Position.Y + heightSign * radius);
            RectangleF rect = new RectangleF(_points[0].Position.X, _points[0].Position.Y, widthSign * radius, heightSign * radius);
            return rect;
        }

        protected override void OnCanvasMouseUp(object sender, MouseEventArgs e)
        {
            base.OnCanvasMouseUp(sender, e);
            GetRect();
        }

        public override Figure Clone()
        {
            return new Circle(this);
        }
    }
}
