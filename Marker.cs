using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public class Marker:IDisposable
    {
        public static bool isObjectChangedRegim = false;

        private Button button;
        private Figure _controllingFigure;
        private bool _isDrag = false;

        public event MouseEventHandler markerMoveEventHandler;
        public event MouseEventHandler markerDownEventHandler;
        public event MouseEventHandler markerUpEventHandler;

        public PointF Position
        {
            get
            {
                return new Point(button.Location.X + button.Size.Width / 2, button.Location.Y + button.Size.Height / 2); ;
            }
            set
            {
                button.Location = new Point((int)value.X-button.Size.Width/2, (int)value.Y - button.Size.Height / 2);
            }
        }

        public Marker(Figure controllingFigure, PointF startPosition)
        {
            _controllingFigure = controllingFigure;
            button = new Button();
            button.Visible = false;
            button.MouseDown += markerMouseDown;
            button.MouseMove += markerMouseMove;
            button.MouseUp += markerMouseUp;
            controllingFigure.canvas.Controls.Add(button);
            button.Size = new Size(10, 10);
            Position = startPosition;
        }

        public bool isDrag
        {
            get
            {
                return _isDrag;
            }
        }
        protected void markerMouseDown(object sender, MouseEventArgs e)
        {
            if (isObjectChangedRegim)
            {
                _isDrag = true;
                if (markerDownEventHandler != null)
                    markerDownEventHandler.Invoke(sender,e);
            }
        }

        protected void markerMouseUp(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                if (markerUpEventHandler != null)
                    markerUpEventHandler.Invoke(sender, e);
                _isDrag = false;
            }
        }
        public void markerMouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                if(markerMoveEventHandler != null)
                    markerMoveEventHandler.Invoke(sender,e);
            }
        }

        public static PointF MarkerToPointF(Marker marker)
        {
            return marker.Position;
        }

        public void Dispose()
        {
            button.Dispose();
        }

        public bool isActive
        {
            get
            {
                return button.Visible;
            }
            set
            {
                button.Visible = value;
            }
        } 
    }
}
