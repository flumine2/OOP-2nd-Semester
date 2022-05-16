using Lab_4.ua.cdu.edu.model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_4.ua.cdu.edu.view
{
    public class BackgroundView : FrontView<Background>
    {
        private static readonly BitmapImage bitmap = new(new Uri("pack://application:,,,/Resources/Background/Track.png"));
        private double cameraPosition;
        
        public BackgroundView(DrawingContext drawingContext, double cameraPosition) : base(drawingContext)
        {
            this.cameraPosition = cameraPosition;
        }

        protected override void Render(Background background)
        {
            drawingContext.DrawImage(bitmap, 
                new Rect
                (
                    background.Position - cameraPosition, 
                    0,
                    Config.BackgroundSize.Width, 
                    Config.BackgroundSize.Height)
                );
        }
    }
}
