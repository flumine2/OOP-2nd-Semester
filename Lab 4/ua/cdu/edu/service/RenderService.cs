using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using Lab_4.Logic.Model;

namespace Lab_4.Logic.Services
{
    public class RenderService
    {
        private static readonly double END_OF_THE_RACE = 38400;
        private static readonly int FPS = 30;
        private static readonly double PIXELS_PER_DIP = 96;
        private static readonly Size BackgroundSize = new Size(1920, 1980);

        private int cameraPosition;
        private Image image;
        private Size size { get; }
        private HorseService horseService;
        private Background[] backgrounds;

        public RenderService(Image image, Size size)
        {
            this.cameraPosition = (int) image.Width / 2;
            this.image = image;
            this.size = size;
            this.horseService = new();
            this.backgrounds = GenerateBackgrounds();
        }

        private Background[] GenerateBackgrounds()
        { 
            Background[] backgrounds = new Background[(int)Math.Ceiling(END_OF_THE_RACE / BackgroundSize.Width)];
            return backgrounds.Select((x, index) => new Background((int)BackgroundSize.Width * index)).ToArray();
        }

        public void RenderFrame() => image.Source = GetRender();

        private BitmapSource GetRender()
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
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].Render(drawingContext, cameraPosition);
            }
            for (int i = 0; i < horseService.Horses.Count; i++)
            {
                horseService.Horses[i].Render(drawingContext, cameraPosition);
            }
        }
    }
}
