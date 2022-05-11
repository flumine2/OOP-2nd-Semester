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
    class RenderService
    {
        public static readonly double END_OF_THE_RACE = 38400;
        public static readonly int FPS = 30;
        public static readonly double PIXEL_PER_DIP = 96;
        public static readonly Size BackgroundSize = new Size(1920, 1980);

        public int cameraPosition;
        private Image image;
        private SizeDelegate size { get; }
        private HorsesService horsesService;
        private Background[] backgrounds;

        public RenderService(Image image, SizeDelegate size)
        {
            cameraPosition = (int) image.Width / 2;
            this.image = image;
            this.size = size;
            horsesService = new HorsesService();
            backgrounds = GenerateBackgrounds();
        }

        private Background[] GenerateBackgrounds()
        { 
            Background[] backgrounds = new Background[(int)Math.Ceiling(END_OF_THE_RACE / BackgroundSize.Width)];
            return backgrounds.Select((x,index) => new Background((int)BackgroundSize.Width * index)).ToArray();
        }

        public void RenderFrame() => image.Source = GetRender();

        private BitmapSource GetRender()
        {
            Size renderSize = size();
            RenderTargetBitmap bitmap = new RenderTargetBitmap(
                Convert.ToInt32(renderSize.Width),
                Convert.ToInt32(renderSize.Height),
                PIXEL_PER_DIP,
                PIXEL_PER_DIP,
                PixelFormats.Pbgra32);

            DrawingVisual drawingVisual = new();

            using (DrawingContext dc = drawingVisual.RenderOpen())
            {
                Render(dc);
            }

            bitmap.Render(drawingVisual);
            return bitmap;
        }

        public void Render(DrawingContext drawingContext)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].Render(drawingContext, cameraPosition);
            }
            for (int i = 0; i < horsesService.Horses.Count; i++)
            {
                horsesService.Horses[i].Render(drawingContext, cameraPosition);
            }
        }

    }
}
