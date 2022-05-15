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

        protected abstract void Render(double cameraPosition, T item);

        public void Render(double cameraPosition, List<T> items) 
        {
            items.ForEach(item => Render(cameraPosition, item));
        }
    }
}
