using Lab_4.ua.cdu.edu.service;
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

namespace Lab_4.ua.cdu.edu.model
{
    public class Horse
    {
        private static readonly int HORSE_HEIGHT = 180;

        public string Name { get; private set; }
        public Color Color { get; private set; }
        public TimeSpan Time { get; private set; }

        public Point Position { get; private set; }
        private double speed;

        public Horse(string name, Color color, double speed, int startPosition)
        {
            this.Name = name;
            this.Color = color;
            this.speed = speed;
            this.Position = new Point(1600, 440 + (startPosition - 1) * HORSE_HEIGHT);
        }

        public void UpdateState()
        {
            Time = HorseService.TIMER.Elapsed;
            ChangeSpeed();
            Position = new Point(Position.X + speed, Position.Y);
        }

        private void ChangeSpeed()
        {
            this.speed = speed * RandomUtil.nextDouble(0.7, 1.3);
        }
    }
}
