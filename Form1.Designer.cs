namespace VectorGraphicsEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.figureWidth = new System.Windows.Forms.NumericUpDown();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lineButton = new System.Windows.Forms.Button();
            this.polilineButton = new System.Windows.Forms.Button();
            this.polygonButton = new System.Windows.Forms.Button();
            this.fillPolygonButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.fillCircleButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.fillEllipseButton = new System.Windows.Forms.Button();
            this.editorButton = new System.Windows.Forms.Button();
            this.Resize = new System.Windows.Forms.Button();
            this.HeightResize = new System.Windows.Forms.Button();
            this.WidthResize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fillColor = new System.Windows.Forms.Button();
            this.lineColor = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvas1 = new Rumster.Figures.Canvas();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.figureWidth)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // figureWidth
            // 
            this.figureWidth.Location = new System.Drawing.Point(3, 224);
            this.figureWidth.Name = "figureWidth";
            this.figureWidth.Size = new System.Drawing.Size(42, 20);
            this.figureWidth.TabIndex = 2;
            this.figureWidth.ValueChanged += new System.EventHandler(this.figureWidth1_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.flowLayoutPanel1.Controls.Add(this.lineButton);
            this.flowLayoutPanel1.Controls.Add(this.polilineButton);
            this.flowLayoutPanel1.Controls.Add(this.polygonButton);
            this.flowLayoutPanel1.Controls.Add(this.fillPolygonButton);
            this.flowLayoutPanel1.Controls.Add(this.circleButton);
            this.flowLayoutPanel1.Controls.Add(this.fillCircleButton);
            this.flowLayoutPanel1.Controls.Add(this.ellipseButton);
            this.flowLayoutPanel1.Controls.Add(this.fillEllipseButton);
            this.flowLayoutPanel1.Controls.Add(this.editorButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(62, 205);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // lineButton
            // 
            this.lineButton.BackColor = System.Drawing.Color.White;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.Location = new System.Drawing.Point(3, 3);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(25, 25);
            this.lineButton.TabIndex = 0;
            this.lineButton.UseVisualStyleBackColor = false;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // polilineButton
            // 
            this.polilineButton.BackColor = System.Drawing.Color.White;
            this.polilineButton.Image = ((System.Drawing.Image)(resources.GetObject("polilineButton.Image")));
            this.polilineButton.Location = new System.Drawing.Point(34, 3);
            this.polilineButton.Name = "polilineButton";
            this.polilineButton.Size = new System.Drawing.Size(25, 25);
            this.polilineButton.TabIndex = 1;
            this.polilineButton.UseVisualStyleBackColor = false;
            this.polilineButton.Click += new System.EventHandler(this.polilineButton_Click);
            // 
            // polygonButton
            // 
            this.polygonButton.BackColor = System.Drawing.Color.White;
            this.polygonButton.Image = ((System.Drawing.Image)(resources.GetObject("polygonButton.Image")));
            this.polygonButton.Location = new System.Drawing.Point(3, 34);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(25, 25);
            this.polygonButton.TabIndex = 2;
            this.polygonButton.UseVisualStyleBackColor = false;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // fillPolygonButton
            // 
            this.fillPolygonButton.BackColor = System.Drawing.Color.White;
            this.fillPolygonButton.Image = ((System.Drawing.Image)(resources.GetObject("fillPolygonButton.Image")));
            this.fillPolygonButton.Location = new System.Drawing.Point(34, 34);
            this.fillPolygonButton.Name = "fillPolygonButton";
            this.fillPolygonButton.Size = new System.Drawing.Size(25, 25);
            this.fillPolygonButton.TabIndex = 6;
            this.fillPolygonButton.UseVisualStyleBackColor = false;
            this.fillPolygonButton.Click += new System.EventHandler(this.fillPolygonButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.BackColor = System.Drawing.Color.White;
            this.circleButton.Image = ((System.Drawing.Image)(resources.GetObject("circleButton.Image")));
            this.circleButton.Location = new System.Drawing.Point(3, 65);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(25, 25);
            this.circleButton.TabIndex = 3;
            this.circleButton.UseVisualStyleBackColor = false;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // fillCircleButton
            // 
            this.fillCircleButton.BackColor = System.Drawing.Color.White;
            this.fillCircleButton.Image = ((System.Drawing.Image)(resources.GetObject("fillCircleButton.Image")));
            this.fillCircleButton.Location = new System.Drawing.Point(34, 65);
            this.fillCircleButton.Name = "fillCircleButton";
            this.fillCircleButton.Size = new System.Drawing.Size(25, 25);
            this.fillCircleButton.TabIndex = 8;
            this.fillCircleButton.UseVisualStyleBackColor = false;
            this.fillCircleButton.Click += new System.EventHandler(this.fillCircleButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.BackColor = System.Drawing.Color.White;
            this.ellipseButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseButton.Image")));
            this.ellipseButton.Location = new System.Drawing.Point(3, 96);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(25, 25);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.UseVisualStyleBackColor = false;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // fillEllipseButton
            // 
            this.fillEllipseButton.BackColor = System.Drawing.Color.White;
            this.fillEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("fillEllipseButton.Image")));
            this.fillEllipseButton.Location = new System.Drawing.Point(34, 96);
            this.fillEllipseButton.Name = "fillEllipseButton";
            this.fillEllipseButton.Size = new System.Drawing.Size(25, 25);
            this.fillEllipseButton.TabIndex = 7;
            this.fillEllipseButton.UseVisualStyleBackColor = false;
            this.fillEllipseButton.Click += new System.EventHandler(this.fillEllipseButton_Click);
            // 
            // editorButton
            // 
            this.editorButton.BackColor = System.Drawing.Color.White;
            this.editorButton.Image = ((System.Drawing.Image)(resources.GetObject("editorButton.Image")));
            this.editorButton.Location = new System.Drawing.Point(3, 127);
            this.editorButton.Name = "editorButton";
            this.editorButton.Size = new System.Drawing.Size(25, 25);
            this.editorButton.TabIndex = 5;
            this.editorButton.UseVisualStyleBackColor = false;
            this.editorButton.Click += new System.EventHandler(this.editorButton_Click);
            // 
            // Resize
            // 
            this.Resize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Resize.Location = new System.Drawing.Point(560, 327);
            this.Resize.Name = "Resize";
            this.Resize.Size = new System.Drawing.Size(12, 12);
            this.Resize.TabIndex = 11;
            this.Resize.UseVisualStyleBackColor = false;
            this.Resize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove_1);
            // 
            // HeightResize
            // 
            this.HeightResize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HeightResize.Location = new System.Drawing.Point(359, 327);
            this.HeightResize.Name = "HeightResize";
            this.HeightResize.Size = new System.Drawing.Size(12, 12);
            this.HeightResize.TabIndex = 10;
            this.HeightResize.UseVisualStyleBackColor = false;
            this.HeightResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeightResize_MouseMove_1);
            // 
            // WidthResize
            // 
            this.WidthResize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WidthResize.Location = new System.Drawing.Point(560, 172);
            this.WidthResize.Name = "WidthResize";
            this.WidthResize.Size = new System.Drawing.Size(12, 12);
            this.WidthResize.TabIndex = 9;
            this.WidthResize.UseVisualStyleBackColor = false;
            this.WidthResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WidthResize_MouseMove_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fillColor);
            this.panel1.Controls.Add(this.lineColor);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.figureWidth);
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 417);
            this.panel1.TabIndex = 12;
            // 
            // fillColor
            // 
            this.fillColor.Location = new System.Drawing.Point(37, 279);
            this.fillColor.Name = "fillColor";
            this.fillColor.Size = new System.Drawing.Size(23, 23);
            this.fillColor.TabIndex = 7;
            this.fillColor.UseVisualStyleBackColor = true;
            this.fillColor.Click += new System.EventHandler(this.fillColor_Click);
            // 
            // lineColor
            // 
            this.lineColor.Location = new System.Drawing.Point(4, 279);
            this.lineColor.Name = "lineColor";
            this.lineColor.Size = new System.Drawing.Size(23, 23);
            this.lineColor.TabIndex = 6;
            this.lineColor.UseVisualStyleBackColor = true;
            this.lineColor.Click += new System.EventHandler(this.lineColor_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot",
            "Custom"});
            this.comboBox1.Location = new System.Drawing.Point(4, 251);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.canvasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // canvasToolStripMenuItem
            // 
            this.canvasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.cutToolStripMenuItem});
            this.canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            this.canvasToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.canvasToolStripMenuItem.Text = "Canvas";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // canvas1
            // 
            this.canvas1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.canvas1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.canvas1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.canvas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.canvas1.Location = new System.Drawing.Point(174, 29);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(389, 301);
            this.canvas1.TabIndex = 8;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(595, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(187, 301);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 447);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HeightResize);
            this.Controls.Add(this.Resize);
            this.Controls.Add(this.WidthResize);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.figureWidth)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown figureWidth;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button Resize;
        private System.Windows.Forms.Button HeightResize;
        private System.Windows.Forms.Button WidthResize;
        private Rumster.Figures.Canvas canvas1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button polilineButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Button fillPolygonButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button fillCircleButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button fillEllipseButton;
        private System.Windows.Forms.Button editorButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button fillColor;
        private System.Windows.Forms.Button lineColor;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

