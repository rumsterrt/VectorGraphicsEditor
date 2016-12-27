using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Rumster.Figures;

namespace VectorGraphicsEditor
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            figureWidth.Value = 1;
            lineColor.BackColor = Color.Black;
            fillColor.BackColor = Color.Black;
            comboBox1.SelectedIndex = 0;
            canvas1.Parent = this;
            KeyDown += canvas1.OnKeyDown;
        }
        //
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        //Canvas size
        #region CanvasSizeButtons
        private void WidthResize_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                WidthResize.Location = new Point(PointToClient(Cursor.Position).X, WidthResize.Location.Y);
                canvas1.SetBounds(canvas1.Location.X, canvas1.Location.Y, WidthResize.Location.X - canvas1.Location.X, canvas1.Height);
                Resize.Location = new Point(canvas1.Location.X + canvas1.Width, canvas1.Location.Y + canvas1.Height);
                HeightResize.Location = new Point(canvas1.Location.X + canvas1.Width / 2, HeightResize.Location.Y);
            }

        }

        private void Resize_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Resize.Location = PointToClient(Cursor.Position);
                HeightResize.Location = new Point(canvas1.Location.X + canvas1.Width / 2, Resize.Location.Y);
                WidthResize.Location = new Point(Resize.Location.X, canvas1.Location.Y + canvas1.Height / 2);
                canvas1.SetBounds(canvas1.Location.X, canvas1.Location.Y, Resize.Location.X - canvas1.Location.X, Resize.Location.Y - canvas1.Location.Y);
            }

        }

        private void HeightResize_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                HeightResize.Location = new Point(HeightResize.Location.X, PointToClient(Cursor.Position).Y);
                canvas1.SetBounds(canvas1.Location.X, canvas1.Location.Y, canvas1.Size.Width, HeightResize.Location.Y - canvas1.Location.Y);
                Resize.Location = new Point(canvas1.Location.X + canvas1.Width, canvas1.Location.Y + canvas1.Height);
                WidthResize.Location = new Point(WidthResize.Location.X, canvas1.Location.Y + canvas1.Height / 2);
            }
        }
        #endregion
        //Color buttons
        #region PropertiesButtons
        private void lineColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            canvas1.updateLineColor(colorDialog1.Color);
            lineColor.BackColor = colorDialog1.Color;
        }

        private void fillColor_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            canvas1.updateFillColor(colorDialog2.Color);
            fillColor.BackColor = colorDialog2.Color;
        }

        private void figureWidth1_ValueChanged(object sender, EventArgs e)
        {
            canvas1.updateLineWidth((int)figureWidth.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            canvas1.updateDashStyle(comboBox1.SelectedIndex);
        }
        #endregion

        //Draw buttons
        #region DrawButtons
        private void lineButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.line;
        }

        private void polilineButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.poliline;
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.polygon;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.circle;
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.ellipse;
        }

        private void editorButton_Click(object sender, EventArgs e)
        {
            Marker.isObjectChangedRegim = true;
            canvas1.currentType = Rumster.Figures.DrawMode.editor;
        }

        private void fillPolygonButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.polygonFill;

        }

        private void fillCircleButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.circleFill;
        }

        private void fillEllipseButton_Click(object sender, EventArgs e)
        {
            canvas1.currentType = Rumster.Figures.DrawMode.ellipseFill;
        }
        #endregion

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvas1.Clear();
        }
    }
}
