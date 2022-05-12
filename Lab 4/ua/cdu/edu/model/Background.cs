using Lab_4.Logic.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_4.Logic.Model
{
    public class Background : IRender
    {
        private int position;
        private static readonly BitmapImage bitmap = new(new Uri("pack://application:,,,/Resources/Background/Track.png", UriKind.Absolute));

        public Background(int position)
        {
            this.position = position;
        }

        public void Render(DrawingContext drawingContext, int cameraPosition)
        {
            drawingContext.DrawImage(bitmap, new Rect(position - cameraPosition, 0, 1920, 1980));
        }
    }
}
