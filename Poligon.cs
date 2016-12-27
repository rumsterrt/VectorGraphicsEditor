using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public class Poligon : Poliline
    {
        public Poligon(Canvas canvas, PointF point1, float width, Color color, Color fillColor, DashStyle dashStyle = DashStyle.Solid) :
            base(canvas, point1, width, color, dashStyle)
        {
            this.fillColor = fillColor;
        }

        public Poligon(Poligon other) :
            base(other)
        {
            fillColor = other.fillColor;
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawPolygon(_linePen, _points.ConvertAll(new Converter<Marker, PointF>(Marker.MarkerToPointF)).ToArray());
            if (_isAdded)
            {
                Pen fillPen = new Pen(fillColor, lineWidth);
                gr.FillPolygon(fillPen.Brush, _points.ConvertAll(new Converter<Marker, PointF>(Marker.MarkerToPointF)).ToArray());
            }
        }

        public override bool IsInsidePoint(Point p)
        {
            RecalcPath();
            return _path.IsVisible(p.X, p.Y);
        }

        protected override void RecalcPath()
        {
            _path.Reset();
            _path.AddPolygon(_points.ConvertAll(new Converter<Marker, PointF>(Marker.MarkerToPointF)).ToArray());
        }

        public override Figure Clone()
        {
            return new Poligon(this);
        }
    }
}
