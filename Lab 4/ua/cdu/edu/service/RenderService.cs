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
using System.Windows.Threading;

namespace Lab_4.ua.cdu.edu.service
{
    public delegate Size ImageSize();
    public class RenderService
    {
        public int TargetHorse
        {
            get => targetHorse;
            set
            {
                targetHorse = value;
            }
        }

        private int targetHorse;
        private Image image;
        private ImageSize imageSize;

        private List<Background> backgrounds;
        private List<Horse> horses;

        public RenderService(Image image, ImageSize imageSize, List<Horse> horses)
        {
            this.image = image;
            this.imageSize = imageSize;
            this.backgrounds = GenerateBackgrounds();
            this.horses = horses;
        }

        private List<Background> GenerateBackgrounds()
        { 
            Background[] backgrounds = new Background[(int)Math.Ceiling(Config.TRACK_LENGTH / Config.BackgroundSize.Width) + 2];
            return backgrounds.Select((x, index) => new Background((int)Config.BackgroundSize.Width * index)).ToList();
        }

        public void RenderFrame() => image.Source = GetFrame();

        private BitmapSource GetFrame()
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap(
                Convert.ToInt32(Math.Max(imageSize().Width, 1)),
                Convert.ToInt32(Math.Max(imageSize().Height, 1)),
                Config.PIXELS_PER_DIP,
                Config.PIXELS_PER_DIP,
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
            double cameraPosition = horses[TargetHorse].Position.X + 2 * Config.HorseSize.Width / 3 - imageSize().Width / 2;
            BackgroundView backgroundView = new BackgroundView(drawingContext);
            backgroundView.Render(cameraPosition, backgrounds);
            HorseView horseView = new HorseView(drawingContext);
            horseView.Render(cameraPosition, horses);
        }
    }
}
