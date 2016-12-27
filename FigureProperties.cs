using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public struct FigureProperties
    {
        public Pen linePen;
        public Color fillColor;
        public List<PointF> points;
        public bool isDispose;
        public FigureProperties(Pen linePen, Color fillColor, List<PointF> points, bool isDispose)
        {
            this.linePen = linePen;
            this.fillColor = fillColor;
            this.points = points == null ? new List<PointF>() : new List<PointF>(points);
            this.isDispose = isDispose;
        }
    }
}
