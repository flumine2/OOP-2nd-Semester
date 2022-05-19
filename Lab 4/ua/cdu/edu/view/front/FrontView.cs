using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.view
{
    public abstract class FrontView<T>
    {
        protected DrawingContext drawingContext;

        protected FrontView(DrawingContext drawingContext)
        {
            this.drawingContext = drawingContext;
        }

        protected abstract void Render(T item);

        public virtual void Render(List<T> items)
        {
            items.ForEach(item => Render(item));
        }
    }
}
