using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.view
{
    public abstract class View<T>
    {
        protected DrawingContext drawingContext;

        protected View(DrawingContext drawingContext) 
        {
            this.drawingContext = drawingContext;
        }

        protected abstract void Render(T item);

        public void Render(List<T> items) 
        {
            items.ForEach(item => Render(item));
        }
    }
}
