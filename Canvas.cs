using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Printing;

namespace Rumster.Figures
{
    public partial class Canvas : UserControl
    {
        public Figures figures = new Figures();
        public int currentStateIndex = 0;
        private Figure _selectedFigure;
        public UndoRedoManager urManager = new UndoRedoManager();

        private Pen _selectRectPen;


        #region PropertiesUpdating
        private int _currentDashStyle = 0;
        private int _figureWidth = 1;
        private Color _currentLineColor = Color.Black;
        private Color _currentFillColor = Color.Black;
        public void updateLineColor(Color color)
        {
            _currentLineColor = color;
            if (_selectedFigure != null)
            {
                _selectedFigure.lineColor = color;
            }
            if (selector != null)
                if (selector.selectedFigures.Count > 0)
                    selector.selectedFigures.ForEach(x => x.lineColor = color);
            Invalidate();
        }

        public void updateFillColor(Color color)
        {
            _currentFillColor = color;
            if (_selectedFigure != null)
            {
                _selectedFigure.fillColor = color;
            }
            if (selector != null)
                if (selector.selectedFigures.Count > 0)
                    selector.selectedFigures.ForEach(x => x.fillColor = color);
            Invalidate();
        }

        public void updateLineWidth(int width)
        {
            _figureWidth = width;
            if (_selectedFigure != null)
            {
                _selectedFigure.lineWidth = width;
            }
            if (selector != null)
                if (selector.selectedFigures.Count > 0)
                    selector.selectedFigures.ForEach(x => x.lineWidth = width);
            Invalidate();
        }

        public void updateDashStyle(int num)
        {
            _currentDashStyle = num;
            if (_selectedFigure != null)
            {
                _selectedFigure.dashStyle = (DashStyle)num;
            }
            if (selector != null)
                if (selector.selectedFigures.Count > 0)
                    selector.selectedFigures.ForEach(x => x.dashStyle = (DashStyle)num);
            Invalidate();
        }
        #endregion

        public DrawMode currentType = DrawMode.editor;
        private Selector selector;

        public Canvas()
        {
            InitializeComponent();
            ResumeLayout();
            figures.Changed += delegate { Refresh(); };
            Figure.seletionPen.DashStyle = DashStyle.DashDotDot;
            DoubleBuffered = true;
            ResizeRedraw = true;
            _selectRectPen = new Pen(Color.Red, 1);
            _selectRectPen.DashStyle = DashStyle.Dash;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics gr)
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;
            if (figures.Count != 0)
            {
                foreach (Figure f in figures)
                        f.Draw(gr);
            }

            if (_selectedFigure != null)
            {
                _selectedFigure.DrawSelection(gr);
            }
            if (selector != null)
                selector.Draw(gr);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            if (figures.Count == 0 || figures[figures.Count - 1].isAdded)
            {
                if (e.Button == MouseButtons.Left)
                {
                    switch (currentType)
                    {
                        case DrawMode.line:
                            urManager.Execute(new AddFigureCommand(figures, new Line(this, e.Location, _figureWidth, _currentLineColor, (DashStyle)_currentDashStyle)));
                            break;
                        case DrawMode.poliline:
                            urManager.Execute(new AddFigureCommand(figures, new Poliline(this, e.Location, _figureWidth, _currentLineColor, (DashStyle)_currentDashStyle)));
                            break;
                        case DrawMode.polygon:
                            urManager.Execute(new AddFigureCommand(figures, new Poligon(this, e.Location, _figureWidth, _currentLineColor, Color.Empty, (DashStyle)_currentDashStyle)));
                            break;
                        case DrawMode.circle:
                            urManager.Execute(new AddFigureCommand(figures, new Circle(this, e.Location, _figureWidth, _currentLineColor, Color.Empty, (DashStyle)_currentDashStyle)));
                            break;
                        case DrawMode.ellipse:
                            urManager.Execute(new AddFigureCommand(figures, new Ellipse(this, e.Location, _figureWidth, _currentLineColor, Color.Empty, (DashStyle)_currentDashStyle)));
                            break;
                        case DrawMode.circleFill:
                            urManager.Execute(new AddFigureCommand(figures, new Circle(this, e.Location, _figureWidth, _currentLineColor, _currentFillColor, (DashStyle)_currentDashStyle)));
                            break;
                        case DrawMode.ellipseFill:
                            urManager.Execute(new AddFigureCommand(figures, new Ellipse(this, e.Location, _figureWidth, _currentLineColor, _currentFillColor, (DashStyle)_currentDashStyle)));
                            break;
                        case DrawMode.polygonFill:
                            urManager.Execute(new AddFigureCommand(figures, new Poligon(this, e.Location, _figureWidth, _currentLineColor, _currentFillColor, (DashStyle)_currentDashStyle)));
                            break;
                    }

                    figures.ForEach(x => x.ActivateMarkers(false));
                    if (currentType == DrawMode.editor)
                    {
                        _selectedFigure = FindFigureByPoint(e.Location);
                        if (_selectedFigure != null)
                        {
                            if (selector != null)
                            {
                                selector.Dispose();
                                selector = null;
                            }
                        }
                        else
                        {
                            selector = new Selector(this, e.Location, 1, Color.Black, 0);
                            selector.selectorUp += delegate (object sender, MouseEventArgs ee) { figures.FindAll(x => selector.IsFigureInsideSelector(x)).ForEach(x => selector.selectedFigures.Add(x)); };
                        }
                        Invalidate();
                    }
                    else
                    {
                        if (_selectedFigure != null)
                        {
                            _selectedFigure.ActivateMarkers(false);
                            _selectedFigure = null;
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                    if (_selectedFigure != null)
                        contextMenuStrip1.Show(PointToScreen(e.Location));
            }
        }
        

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (currentType != DrawMode.editor)
                return;
            
                Figure figure = FindFigureByPoint(e.Location);
                if (figure != null)
                    Cursor = Cursors.Hand;
                else
                    Cursor = Cursors.Default;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (currentType != DrawMode.editor)
                return;
            _selectedFigure = FindFigureByPoint(e.Location);
            //if (_selectedFigure != null)
            //{
            //    _selectedFigure.ActivateMarkers(true);
            //    if (selector != null)
            //        if (_selectedFigure != selector)
            //        {
            //            selector.Dispose();
            //            selector = null;
            //        }
            //}
        }

        public void OnKeyDown(Object secnder,KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        OnCopy();
                        break;
                    case Keys.X:
                        OnCut();
                        break;
                    case Keys.V:
                        OnPaste();
                        break;
                    case Keys.Z:
                        if(urManager.CanUndo)
                            urManager.Undo();
                        break;
                    case Keys.Y:
                        if (urManager.CanRedo)
                            urManager.Redo();
                        break;
                }
                e.Handled = true;
            }
            Invalidate();
        }


        private Figure FindFigureByPoint(Point p)
        {
            if (selector != null)
            {
                if (selector.selectedFigures.Count == 0)
                    selector = null;
                else
                if (selector.IsInsidePoint(p))
                    return selector;
            }
            return figures.FindLast(x => x.IsInsidePoint(p));
        }

        private void deleteFigureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure == null)
                return;
            urManager.Execute(new RemoveFigureCommand(figures, _selectedFigure));
            Invalidate();
        }

        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                figures.Remove(_selectedFigure);
                figures.Add(_selectedFigure);
                Invalidate();
            }
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                figures.Remove(_selectedFigure);
                figures.Insert(0, _selectedFigure);
                Invalidate();
            }
        }

        public Point GetCanvasPoint(Point point)
        {
            Point resultPoint = point;
            if (resultPoint.X < 0)
                resultPoint.X = 0;
            if (resultPoint.X > Width)
                resultPoint.X = Width;
            if (resultPoint.Y < 0)
                resultPoint.Y = 0;
            if (resultPoint.Y > Height)
                resultPoint.Y = Height;
            return resultPoint;
        }

        //cutPasteCopy
        private Figure copycutObject = null;
        public void OnCut()
        {
            if(selector!=null)
            {
                copycutObject = selector.Clone();
                selector.Dispose();
                foreach(Figure f in selector.selectedFigures)
                    urManager.Execute(new RemoveFigureCommand(figures,f));
                selector = null;
                return;
            }
            if (_selectedFigure == null)
                return;
            copycutObject = _selectedFigure.Clone();
            urManager.Execute(new RemoveFigureCommand(figures, _selectedFigure));
            _selectedFigure = null;
        }

        public void OnPaste()
        {
            if (copycutObject == null)
                return;
            if (copycutObject.GetType()==(typeof(Selector)))
            {
                foreach (Figure f in ((Selector)copycutObject).selectedFigures)
                    figures.Add(f);
                selector = (Selector)copycutObject;
                return;
            }
            if (_selectedFigure != null)
                _selectedFigure.ActivateMarkers(false);
            figures.Add(copycutObject.Clone());
            _selectedFigure = figures[figures.Count - 1];
            _selectedFigure.ActivateMarkers(true);
        }

        public void OnCopy()
        {
            if (selector != null)
            {
                copycutObject = selector.Clone();
                return;
            }
            if (_selectedFigure == null)
                return;
            copycutObject = _selectedFigure.Clone();
        }

        public void Clear()
        {
            urManager.Execute(new RemoveFigureCommand(figures, figures));
        }
    }
}
