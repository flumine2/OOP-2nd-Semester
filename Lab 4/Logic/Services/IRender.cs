using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.Logic.Services
{
    interface IRender
    {
        void Render(DrawingContext drawingContext, int cameraPosition);
    }
}
