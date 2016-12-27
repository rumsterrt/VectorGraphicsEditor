using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumster.Figures
{
    public class Figures : List<Figure>
    {
        public event EventHandler Changed = delegate { };

        public virtual void OnChanged()
        {
            Changed(this, EventArgs.Empty);
        }

        internal void RemoveLastFigure()
        {
            if (Count == 0) throw new ArgumentException();
            RemoveAt(Count - 1);
        }
    }
}
