using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.view;
using Lab_4.ua.cdu.edu.service.animation;

namespace Lab_4.ua.cdu.edu.service
{
    public class RenderService
    {
        private static readonly double END_OF_THE_RACE = 38400;
        private static readonly int FPS = 30;
        private static readonly double PIXELS_PER_DIP = 96;
        
        private static readonly Size BackgroundSize = new Size(1920, 1980);

        private int cameraPosition;
        private Image image;
        private Size size;

        private List<Background> backgrounds;
        private List<Horse> horses;

        public RenderService(Image image, Size size, List<Horse> horses)
        {
            this.cameraPosition = (int)image.ActualWidth / 2;
            this.image = image;
            this.size = size;
            this.backgrounds = GenerateBackgrounds();
            this.horses = horses;
        }

        private List<Background> GenerateBackgrounds()
        { 
            Background[] backgrounds = new Background[(int)Math.Ceiling(END_OF_THE_RACE / BackgroundSize.Width)];
            return backgrounds.Select((x, index) => new Background((int)BackgroundSize.Width * index)).ToList();
        }

        public void RenderFrame() => image.Source = GetFrame();

        private BitmapSource GetFrame()
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap(
                Convert.ToInt32(size.Width),
                Convert.ToInt32(size.Height),
                PIXELS_PER_DIP,
                PIXELS_PER_DIP,
                PixelFormats.Pbgra32);

            DrawingVisual drawingVisual = new();

            using (DrawingContext dc = drawingVisual.RenderOpen())
            {
                Render(dc);
            }

            bitmap.Render(drawingVisual);

            return bitmap;
        }

        private void Render(DrawingContext drawingContext)
        {
            BackgroundView backgroundView = new BackgroundView(drawingContext);
            backgroundView.Render(cameraPosition, backgrounds);
            HorseView horseView = new HorseView(drawingContext);
            horseView.Render(cameraPosition, horses);
        }
    }
}
