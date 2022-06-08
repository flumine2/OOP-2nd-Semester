using Lab_4.ua.cdu.edu.model;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_4.ua.cdu.edu.service.animation
{
    public class HorseAnimationService : AnimationService<Horse>
    {
        public static HorseAnimationService Instance { get; } = new();
        private Dictionary<Color, List<ImageSource>> animationCache = new Dictionary<Color, List<ImageSource>>();

        static HorseAnimationService()
        {
            Directory.SetCurrentDirectory("..");
            Directory.SetCurrentDirectory("..");
        }

        private HorseAnimationService()
        {
        }

        public List<ImageSource> animate(Horse item)
        {
            if (animationCache.ContainsKey(item.Color))
            {
                return animationCache[item.Color];
            }

            animationCache.Add(item.Color, GetHorseAnimation(item.Color));

            return animationCache[item.Color];
        }

        public List<ImageSource> GetHorseAnimation(Color color)
        {
            List<BitmapImage> bitmap_image_list = ReadImageList("Resources/Horses");
            List<BitmapImage> mask_image_list = ReadImageList("Resources/HorsesMask");

            return bitmap_image_list.Select((item, index) => GetImageInColor(item, mask_image_list[index], color)).ToList();
        }

        private List<BitmapImage> ReadImageList(string directory)
        {
            return Directory.GetFiles(directory)
                .Select(path => new BitmapImage(new Uri(path.Replace("\\\\", "/"), UriKind.Relative)))
                .ToList();
        }

        private ImageSource GetImageInColor(BitmapImage image, BitmapImage mask, Color color)
        {
            WriteableBitmap image_bmp = new(image);
            WriteableBitmap mask_bmp = new(mask);
            WriteableBitmap output_bmp = BitmapFactory.New(image.PixelWidth, image.PixelHeight);
            output_bmp.ForEach((x, y, c) =>
            {
                return MultiplyColors(image_bmp.GetPixel(x, y), color, mask_bmp.GetPixel(x, y).A);
            });

            return output_bmp;
        }

        private Color MultiplyColors(Color color_1, Color color_2, byte alpha)
        {
            double amount = alpha / 255.0;
            byte r = (byte)(color_2.R * amount + color_1.R * (1 - amount));
            byte g = (byte)(color_2.G * amount + color_1.G * (1 - amount));
            byte b = (byte)(color_2.B * amount + color_1.B * (1 - amount));

            return Color.FromArgb(color_1.A, r, g, b);
        }
    }
}
