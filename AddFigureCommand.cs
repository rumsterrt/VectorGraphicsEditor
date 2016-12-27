using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumster.Figures
{
    public class AddFigureCommand : Command
    {
        private Figures firgures;
        private Figure figure;

        public AddFigureCommand(Figures firgures, Figure figure)
        {
            this.firgures = firgures;
            this.figure = figure;
        }

        public string Name
        {
            get { return "Add "+figure.GetType(); }
        }

        public override void Execute()
        {
            firgures.Add(figure);
            //сигнализируем об изменениях
            firgures.OnChanged();
        }

        public override void UnExecute()
        {
            firgures.Remove(figure);
            //сигнализируем об изменениях
            firgures.OnChanged();
        }
    }

}
