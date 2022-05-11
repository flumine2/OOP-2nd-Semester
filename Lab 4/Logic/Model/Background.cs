using Lab_4.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_4.Logic.Model
{
    class Background : IRender
    {
        private int position;
        private static readonly BitmapImage bitmap = new(new Uri("../Resources/Background/Trace.png"));

        public Background(int x_position)
        {
            position = x_position;
        }

        public void Render(DrawingContext drawingContext, int cameraPosition)
        {
            drawingContext.DrawImage(bitmap, new Rect(position - cameraPosition, 0, 1920, 1980));
        }
    }
}
