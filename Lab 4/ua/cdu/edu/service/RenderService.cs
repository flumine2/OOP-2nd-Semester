using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_4.ua.cdu.edu.service
{
    public delegate Size ImageSize();

    public class RenderService
    {
        private int _targetHorse;
        private readonly Image _image;
        private readonly ImageSize _imageSize;

        private readonly List<Background> _backgrounds;
        private readonly List<Horse> _horses;

        public int TargetHorse
        {
            get => _targetHorse;
            set
            {
                _targetHorse = value;
            }
        }

        public RenderService(Image image, ImageSize imageSize, List<Horse> horses)
        {
            _image = image;
            _imageSize = imageSize;
            _backgrounds = GenerateBackgrounds();
            _horses = horses;
        }

        private List<Background> GenerateBackgrounds()
        {
            Background[] backgrounds = new Background[(int)Math.Ceiling(Config.TRACK_LENGTH / Config.BackgroundSize.Width) + 2];
            return backgrounds.Select((x, index) => new Background((int)Config.BackgroundSize.Width * index)).ToList();
        }

        public void RenderFrame() => _image.Source = GetFrame();

        private BitmapSource GetFrame()
        {
            RenderTargetBitmap bitmap = new(
                Convert.ToInt32(Math.Max(_imageSize().Width, Config.TRACK_WIDTH)),
                Convert.ToInt32(Math.Max(_imageSize().Height, Config.TRACK_HEIGHT)),
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
            double cameraPosition = _horses[TargetHorse].Position.X + 2 * Config.HorseSize.Width / 3 - _imageSize().Width / 2;
            BackgroundView backgroundView = new(drawingContext, cameraPosition);
            backgroundView.Render(_backgrounds);
            HorseView horseView = new(drawingContext, cameraPosition);
            horseView.Render(_horses);
        }
    }
}
