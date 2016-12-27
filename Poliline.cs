using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public class Poliline : Figure
    {
        public Poliline(Canvas canvas, PointF point1, float width, Color color, DashStyle dashStyle = DashStyle.Solid)
        {
            this.canvas = canvas;
            _points.Add(new Marker(this, point1));
            _points.Add(new Marker(this, point1));
            _linePen = new Pen(color, width);
            _linePen.DashStyle = dashStyle;
            canvas.MouseDown += CanvasMouseDown;
            canvas.MouseUp += OnCanvasMouseUp;
            canvas.MouseMove += OnCanvasMouseMove;
            AddZeroFigureState();
        }

        public Poliline(Poliline other)
        {
            _isAdded = true;
             canvas = other.canvas;
            foreach (Marker m in other._points)
                _points.Add(new Marker(this, m.Position));
            _points.ForEach(x => x.markerMoveEventHandler += delegate (object s, MouseEventArgs mea)
            {
                x.Position = canvas.GetCanvasPoint(Cursor.Position);
                canvas.Refresh();
            });
            _points.ForEach(x => x.markerUpEventHandler += delegate (object s, MouseEventArgs mea)
            {
                x.Position = canvas.GetCanvasPoint(Cursor.Position);
                canvas.urManager.Execute(new UpdateFigureCommand(this, GetProperties()));
                canvas.Refresh();
            });
            _linePen = new Pen(other.lineColor, other.lineWidth);
            AddZeroFigureState();
        }

        protected override void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _points.Add(new Marker(this, canvas.GetCanvasPoint(e.Location)));
            if (e.Button == MouseButtons.Right&&_points.Count>1)
            {
                _points.ForEach(x => x.markerMoveEventHandler += delegate (object s, MouseEventArgs mea)
                {
                    x.Position = canvas.GetCanvasPoint(canvas.PointToClient(Cursor.Position));
                    canvas.Refresh();
                });
                _points.ForEach(x => x.markerUpEventHandler += delegate (object s, MouseEventArgs mea)
                {
                    x.Position = canvas.GetCanvasPoint(canvas.PointToClient(Cursor.Position));
                    canvas.urManager.Execute(new UpdateFigureCommand(this, GetProperties()));
                    canvas.Refresh();
                });
                canvas.MouseDown -= CanvasMouseDown;
                canvas.MouseUp -= OnCanvasMouseUp;
                canvas.MouseMove -= OnCanvasMouseMove;
                _isAdded = true;
                canvas.Refresh();
                canvas.urManager.Execute(new UpdateFigureCommand(this, GetProperties()));
            }
        }

        protected override void OnCanvasMouseUp(object sender, MouseEventArgs e)
        {
            _points[_points.Count - 1].Position = canvas.GetCanvasPoint(e.Location);
            canvas.Refresh();
        }

        protected override void OnCanvasMouseMove(object sender, MouseEventArgs e)
        {
            _points[_points.Count - 1].Position = canvas.GetCanvasPoint(e.Location);
            canvas.Refresh();
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawLines(_linePen, _points.ConvertAll(new Converter<Marker, PointF>(Marker.MarkerToPointF)).ToArray());
        }

        public override void DrawSelection(Graphics gr)
        {
            float minX = _points.Min(x => x.Position.X);
            float minY = _points.Min(x => x.Position.Y);
            float maxX = _points.Max(x => x.Position.X);
            float maxY = _points.Max(x => x.Position.Y);
            gr.DrawRectangle(seletionPen, minX, minY, Math.Abs(maxX - minX), Math.Abs(maxY - minY));
        }

        public override bool IsInsidePoint(Point p)
        {
            RecalcPath();
            return _path.IsOutlineVisible(p, _clickPen);
        }

        protected virtual void RecalcPath()
        {
            _path.Reset();
            _path.AddLines(_points.ConvertAll(new Converter<Marker, PointF>(Marker.MarkerToPointF)).ToArray());
        }

        public override RectangleF GetRect()
        {
            float minX = _points.Min(x => x.Position.X);
            float minY = _points.Min(x => x.Position.Y);
            float maxX = _points.Max(x => x.Position.X);
            float maxY = _points.Max(x => x.Position.Y);
            return new RectangleF(minX, minY, Math.Abs(maxX - minX), Math.Abs(maxY - minY));
        }
        
        public override Figure Clone()
        {
            return new Poliline(this);
        }
    }
}
