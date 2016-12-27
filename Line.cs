using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public class Line : Poliline
    {
        public Line(Canvas canvas, PointF point1, float width, Color color, DashStyle dashStyle = DashStyle.Solid):
            base(canvas, point1, width, color, dashStyle)
        {
        }

        public Line(Line other):
            base(other)
        {
        }

        protected override void OnCanvasMouseUp(object sender, MouseEventArgs e)
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
            _points[1].Position = canvas.GetCanvasPoint(e.Location);
            canvas.Refresh();
            canvas.MouseDown -= CanvasMouseDown;
            canvas.MouseUp -= OnCanvasMouseUp;
            canvas.MouseMove -= OnCanvasMouseMove;
            _isAdded = true;
            canvas.urManager.Execute(new UpdateFigureCommand(this, GetProperties()));
        }

        public override Figure Clone()
        {
            return new Line(this);
        }
    }
}
