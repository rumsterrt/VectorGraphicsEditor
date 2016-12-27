using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public class Ellipse : Line
    {
        public Ellipse(Canvas canvas, PointF point1, float width, Color color, Color fillColor, DashStyle dashStyle = DashStyle.Solid) :
            base(canvas, point1, width, color, dashStyle)
        {
            this.fillColor = fillColor;
        }

        public Ellipse(Ellipse other) :
            base(other)
        {
            fillColor = other.fillColor;
        }

        public override void Draw(Graphics gr)
        {
            RectangleF rect = GetRect();
            gr.DrawEllipse(_linePen, rect);
            Pen fillPen = new Pen(fillColor, lineWidth);
            gr.FillEllipse(fillPen.Brush, rect);
        }

        public override bool IsInsidePoint(Point p)
        {
            RecalcPath();
            return _path.IsVisible(p.X, p.Y);
        }

        protected override void RecalcPath()
        {
            _path.Reset();
            _path.AddEllipse(GetRect());
        }

        public override Figure Clone()
        {
            return new Ellipse(this);
        }
    }
}
