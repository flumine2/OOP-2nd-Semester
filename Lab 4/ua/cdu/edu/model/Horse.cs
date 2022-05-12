using Lab_4.Logic.Services;
using Lab_4.ua.cdu.edu.util;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_4.Logic.Model
{
    public class Horse : IRender
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }
        private int StartPosition;
        private List<ImageSource> animation;

        public TimeSpan Time { get; private set; }
        public Point Position { get; private set; }
        private int speed;
        private double acceleration;

        public Horse(string name, Color color, int speed, int startpos)
        {
            this.Name = name;
            this.Color = color;
            this.speed = speed;
            this.StartPosition = startpos;

            this.animation = GetHorseAnimation(color);
            this.Position = new Point(1600, 440 + (StartPosition - 1) * animation[0].Height);
        }

        public void Render(DrawingContext dc, int cameraPosition)
        {
            dc.DrawImage(
                animation[0],
                new Rect
                (
                    Position.X - cameraPosition,
                    Position.Y,
                    animation[0].Width,
                    animation[0].Height
                )
            );
        }

        public void ChangeState()
        {
            Time = HorseService.TIMER.Elapsed;

            ChangeAcceleration();
            Position = new Point(Position.X + acceleration, Position.Y);
        }

        private void ChangeAcceleration()
        {
            this.acceleration = speed * RandomUtil.nextDouble(0.7, 1.3);
        }

        public List<ImageSource> GetHorseAnimation(Color color)
        {
            const int count = 12;
            List<BitmapImage> bitmap_image_list = ReadImageList("Resources/Horses", "WithOutBorder_", ".png", count);
            List<BitmapImage> mask_image_list = ReadImageList("Resources/HorsesMask", "mask_", ".png", count);
            return bitmap_image_list.Select((item, index) => GetImageWithColor(item, mask_image_list[index], color)).ToList();
        }

        private List<BitmapImage> ReadImageList(string path, string name, string format, int count)
        {
            path = $"pack://application:,,,/{path}/{name}";
            List<BitmapImage> list = new();
            for (int i = 0; i < count; i++)
            {
                BitmapImage img = new(new Uri(path + string.Format("{0:0000}", i) + format, UriKind.Absolute));
                list.Add(img);
            }
            return list;
        }

        private ImageSource GetImageWithColor(BitmapImage image, BitmapImage mask, Color color)
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
