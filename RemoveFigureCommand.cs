using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumster.Figures
{
    public class RemoveFigureCommand:Command
    {
        private Figures firgures;
        private List<Figure> figure = new List<Figure>();

        public RemoveFigureCommand(Figures firgures, Figure figure)
        {
            this.firgures = firgures;
            this.figure.Add(figure);
        }

        public RemoveFigureCommand(Figures firgures, List<Figure> figure)
        {
            this.firgures = firgures;
            this.figure.AddRange(figure);
        }

        public string Name
        {
            get { return "Remove " + figure.GetType(); }
        }

        public override void Execute()
        {
            foreach(Figure f in figure)
                firgures.Remove(f);
            //сигнализируем об изменениях
            firgures.OnChanged();
        }

        public override void UnExecute()
        {
            firgures.AddRange(figure);
            //сигнализируем об изменениях
            firgures.OnChanged();
        }
    }

}
