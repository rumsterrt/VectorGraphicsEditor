using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rumster.Figures
{
    public class UpdateFigureCommand : Command
    {
        private Figure figure;
        private FigureProperties properties;
        private FigureProperties prevProperties;

        public UpdateFigureCommand(Figure figure)
        {
            this.figure = figure;
            this.properties = figure.GetProperties();
        }

        public string Name
        {
            get { return "Update figure"; }
        }

        public override void Execute()
        {
            //запоминаем предыдущий цвет
            prevProperties = figure.GetProperties();
            //присваиваем новый цвет
            figure.UpdateProperties(properties);
            //сигнализируем об изменениях
            //rects.OnChanged();
        }

        public override void UnExecute()
        {
            //возвращаем предыдущий цвет
            figure.UpdateProperties(prevProperties);
            //сигнализируем об изменениях
            //rects.OnChanged();
        }
    }
}
