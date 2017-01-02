using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    
    public abstract class Figure : ICloneable
    {
        protected bool _isDispose = false;
        protected static Pen _clickPen = new Pen(Color.Transparent, 3);
        public static Pen seletionPen = new Pen(Color.Red, 0.1f);

        protected int _currentIndex = 0;

        readonly GraphicsPath serializablePath = new GraphicsPath();
        protected GraphicsPath _path { get { return serializablePath; } }
        protected List<FigureProperties> _changeList= new List<FigureProperties>();
        protected List<Marker> _points = new List<Marker>();
        protected List<PointF> _beforeSelectionPointsPosition = new List<PointF>();
        protected bool _isActive = false;
        protected bool _isAdded = false;

        protected Pen _linePen;

        public Color fillColor { get; set;}
        public Color lineColor { get { return _linePen.Color;} set { _linePen.Color = value; } }
        public DashStyle dashStyle { get { return _linePen.DashStyle; } set { _linePen.DashStyle = value; } }
        public float lineWidth { get { return _linePen.Width; } set { _linePen.Width = value; } }

        public bool isAdded
        {
            private set
            {
                _isAdded = value;
            }
            get
            {
                return _isAdded;
            }
        }
        public bool isActive
        {
            private set
            {
                _isActive = value;
            }
            get
            {
                return _isActive;
            }
        }

        public Canvas canvas {
            get;
            protected set;
        }

        public bool isDispose {
            get
            {
                return _isDispose;
            }
        }

        protected abstract void OnCanvasMouseDown(object sender, MouseEventArgs e);
        protected abstract void OnCanvasMouseUp(object sender, MouseEventArgs e);
        protected abstract void OnCanvasMouseMove(object sender, MouseEventArgs e);
        protected abstract void OnCanvasMouseStartDrag(object sender, MouseEventArgs e);
        protected abstract void OnCanvasMouseDrag(object sender, MouseEventArgs e);
        protected abstract void OnCanvasMouseEndDrag(object sender, MouseEventArgs e);
        public abstract void Draw(Graphics gr);
        public abstract void DrawSelection(Graphics gr);
        public abstract bool IsInsidePoint(Point p);
        public abstract RectangleF GetRect();
        public abstract Figure Clone();
        object ICloneable.Clone()
        {
            return Clone();
        }

        //работа с множественным выделением
        public void onSelectorStart()
        {
            _beforeSelectionPointsPosition = new List<PointF>();
            _beforeSelectionPointsPosition.Clear();
            _beforeSelectionPointsPosition.AddRange(_points.ConvertAll(new Converter<Marker, PointF>(Marker.MarkerToPointF)));
        }

        public void onSelectorMove(RectangleF startRect, RectangleF currentRect)
        {
            PointF procent = new PointF(currentRect.Width / startRect.Width - 1, currentRect.Height / startRect.Height - 1);
            PointF offset = new PointF(currentRect.Location.X - startRect.Location.X, currentRect.Location.Y - startRect.Location.Y);
            for (int i = 0; i < _points.Count; i++)
            {
                PointF pointsLocal = new PointF(startRect.Location.X - _beforeSelectionPointsPosition[i].X, startRect.Location.Y - _beforeSelectionPointsPosition[i].Y);
                _points[i].Position = new PointF(_beforeSelectionPointsPosition[i].X - procent.X * pointsLocal.X + offset.X, _beforeSelectionPointsPosition[i].Y - procent.Y * pointsLocal.Y + offset.Y);
            }
        }

        public virtual void ActivateMarkers(bool activate)
        {
            _points.ForEach(x => x.isActive = activate);
        }

        public void OnSelectorFinish()
        {
        }

        //Undo Redo

        public void UpdateProperties(FigureProperties properties)
        {
            if (properties.linePen != null)
                _linePen = (Pen)properties.linePen.Clone();
            fillColor = properties.fillColor;
            for (int i = 0; i < properties.points.Count; i++)
                _points[i].Position = properties.points[i];
            _isDispose = properties.isDispose;
            canvas.Refresh();
        }

        public virtual void SetOffset(float dx, float dy)
        {
            _points.ForEach(x => x.Position = new PointF(x.Position.X + dx, x.Position.Y + dy));
            canvas.Refresh();
        }

        public FigureProperties GetProperties()
        {
            return new FigureProperties(_linePen, fillColor, _points.ConvertAll(new Converter<Marker, PointF>(Marker.MarkerToPointF)),isDispose);
        }
    }
}
