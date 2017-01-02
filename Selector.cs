using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumster.Figures
{
    class Selector:Line,IDisposable
    {
        protected Marker[] selectorMarkers = new Marker[8];

        private RectangleF startMoveSelectorSize;
        private RectangleF currentMoveSelectorSize;
        private PointF startUseMarkerPosition;

        public event MouseEventHandler selectorMove;
        public event MouseEventHandler selectorUp;
        public List<Figure> selectedFigures = new List<Figure>();//Сделать get

        public Selector(Canvas canvas, PointF point1, float width, Color color, DashStyle dashStyle = DashStyle.Solid):
            base(canvas,point1,width,color,dashStyle)
        {
            for (int i = 0; i < selectorMarkers.Length; i++)
            {
                selectorMarkers[i] = new Marker(this, PointF.Empty);
                selectorMarkers[i].markerDownEventHandler += onMarkerMouseDown;
                selectorMarkers[i].markerUpEventHandler += onMarkerMouseUp;
                selectorMarkers[i].markerMoveEventHandler += onMarkerMouseMove;
            }
        }

        public Selector(Selector other):
            base(other)
        {
            for (int i = 0; i < selectorMarkers.Length; i++)
            {
                selectorMarkers[i] = new Marker(this, PointF.Empty);
                selectorMarkers[i].markerDownEventHandler += onMarkerMouseDown;
                selectorMarkers[i].markerUpEventHandler += onMarkerMouseUp;
                selectorMarkers[i].markerMoveEventHandler += onMarkerMouseMove;
            }
            foreach (Figure f in other.selectedFigures)
                selectedFigures.Add(f.Clone());
        }

        protected override void OnCanvasMouseUp(object sender, MouseEventArgs e)
        {
            canvas.MouseMove -= OnCanvasMouseMove;
            canvas.MouseUp -= OnCanvasMouseUp;
            if (!_isAdded)
            {
                if (selectorUp != null)
                    selectorUp.Invoke(sender, e);
                if (!IsCorrectSize() || selectedFigures.Count == 0)
                {
                    Dispose();
                    canvas.Refresh();
                    return;
                }
                ActivateMarkers(true);
                _points[1].Position = canvas.GetCanvasPoint(e.Location);
                _isAdded = true;
                float bottom = selectedFigures.Max(x => x.GetRect().Bottom);
                float top = selectedFigures.Min(x => x.GetRect().Top);
                float left = selectedFigures.Min(x => x.GetRect().Left);
                float right = selectedFigures.Max(x => x.GetRect().Right);
                _points[0].Position = new PointF(left, top);
                _points[1].Position = new PointF(right, bottom);
                canvas.Refresh();
            }
        }

        public override void ActivateMarkers(bool activate)
        {
            if (!IsCorrectSize())
                return;
            Array.ForEach(selectorMarkers, x => x.isActive = true);
        }

        protected override void OnCanvasMouseMove(object sender, MouseEventArgs e)
        {
            canvas.MouseDown -= OnCanvasMouseDown;
            if (!_isAdded)
            {
                _points[1].Position = e.Location;
                if (selectorMove != null)
                    selectorMove.Invoke(sender, e);
                canvas.Refresh();
            }
        }

        protected override void OnCanvasMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _points.Add(new Marker(this, e.Location));
        }

        private bool IsCorrectSize()
        {
            return (Math.Sqrt(Math.Pow(_points[1].Position.X - _points[0].Position.X, 2) + Math.Pow(_points[1].Position.Y - _points[0].Position.Y, 2)) >= 25);
        }

        public override void Draw(Graphics gr)
        {
            PointF Point1 = _points[0].Position;
            PointF Point2 = _points[1].Position;
            gr.DrawRectangle(_linePen, Point2.X - Point1.X >= 0 ? Point1.X : Point1.X - Math.Abs(Point2.X - Point1.X), Point2.Y - Point1.Y >= 0 ? Point1.Y : Point1.Y - Math.Abs(Point2.Y - Point1.Y), Math.Abs(Point2.X - Point1.X), Math.Abs(Point2.Y - Point1.Y));
            selectorMarkers[0].Position = new PointF(Point1.X, Point1.Y);
            selectorMarkers[1].Position = new PointF(Point1.X + (Point2.X - Point1.X) / 2, Point1.Y);
            selectorMarkers[2].Position = new PointF(Point2.X, Point1.Y);
            selectorMarkers[3].Position = new PointF(Point2.X, Point1.Y + (Point2.Y - Point1.Y) / 2);
            selectorMarkers[4].Position = new PointF(Point2.X, Point2.Y);
            selectorMarkers[5].Position = new PointF(Point2.X - (Point2.X - Point1.X) / 2, Point2.Y);
            selectorMarkers[6].Position = new PointF(Point1.X, Point2.Y);
            selectorMarkers[7].Position = new PointF(Point1.X, Point1.Y + (Point2.Y - Point1.Y) / 2);
        }

        public override void DrawSelection(Graphics gr)
        {
            
        }

        public override bool IsInsidePoint(Point p)
        {
            RecalcPath();
            return _path.IsVisible(p);
        }

        public bool IsFigureInsideSelector(Figure f)
        {
            float bottom = f.GetRect().Bottom;
            float top = f.GetRect().Top;
            float left = f.GetRect().Left;
            float right = f.GetRect().Right;
            RecalcPath();
            return _path.IsVisible(new PointF(left, top)) && _path.IsVisible(new PointF(right,bottom));
        }

        protected override void RecalcPath()
        {
            _path.Reset();
            _path.AddRectangle(GetRect());
        }

        public override void SetOffset(float dx, float dy)
        {
            _points[0].Position = new PointF(_points[0].Position.X + dx, _points[0].Position.Y + dy);
            _points[1].Position = new PointF(_points[1].Position.X + dx, _points[1].Position.Y + dy);
            selectedFigures.ForEach(x => x.SetOffset(dx, dy));
            canvas.Refresh();
        }

        public void updatedSize(float dx, float dy)
        {
            int currentMarker = Array.FindIndex(selectorMarkers, x => x.isDrag);
            PointF Point1 = _points[0].Position;
            PointF Point2 = _points[1].Position;
            switch (currentMarker)
            {
                case 0:
                    _points[0].Position = new PointF(Point1.X + dx, Point1.Y+dy );
                    break;
                case 1:
                    _points[0].Position = new PointF(Point1.X, Point1.Y + dy);
                    break;
                case 2:
                    _points[0].Position = new PointF(Point1.X, Point1.Y + dy);
                    _points[1].Position = new PointF(Point2.X + dx, Point2.Y);
                    break;
                case 3:
                    _points[1].Position = new PointF(Point2.X + dx, Point2.Y);
                    break;
                case 4:
                    _points[1].Position = new PointF(Point2.X + dx, Point2.Y + dy);
                    break;
                case 5:
                    _points[1].Position = new PointF(Point2.X, Point2.Y + dy);
                    break;
                case 6:
                    _points[0].Position = new PointF(Point1.X + dx, Point1.Y);
                    _points[1].Position = new PointF(Point2.X, Point2.Y + dy);
                    break;
                case 7:
                    _points[0].Position = new PointF(Point1.X + dx, Point1.Y);
                    break;
            }
            currentMoveSelectorSize = GetRect();
            selectedFigures.ForEach(x => x.onSelectorMove(startMoveSelectorSize, currentMoveSelectorSize));
            canvas.Refresh();
        }

        public void Dispose()
        {
            _isDispose = true;
            Array.ForEach(selectorMarkers, x => x.Dispose());
            canvas.Refresh();
        }

        public void onMarkerMouseDown(object sender, MouseEventArgs e)
        {
            int currentMarker = Array.FindIndex(selectorMarkers, x => x.isDrag);
            startMoveSelectorSize = GetRect();
            selectedFigures.ForEach(x => x.onSelectorStart());
            startUseMarkerPosition = e.Location;
        }

        public void onMarkerMouseMove(object sender, MouseEventArgs e)
        {
            int currentMarker = Array.FindIndex(selectorMarkers, x => x.isDrag);
            PointF currentUseMarkerPosition = e.Location;
            updatedSize(currentUseMarkerPosition.X - startUseMarkerPosition.X, currentUseMarkerPosition.Y - startUseMarkerPosition.Y);
            canvas.Refresh();
        }

        public void onMarkerMouseUp(object sender, MouseEventArgs e)
        {
            int currentMarker = Array.FindIndex(selectorMarkers, x => x.isDrag);
            canvas.Refresh();
        }

        public override Figure Clone()
        {
            return new Selector(this);
        }
    }
}
