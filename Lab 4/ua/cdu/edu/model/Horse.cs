using Lab_4.Logic.Services;
using Lab_4.ua.cdu.edu.util;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.Logic.Model
{
    public class Horse : IRender
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }

        public TimeSpan Time { get; private set; }
        private int speed;
        private double acceleration;

        public Horse(string name, Color color, int speed)
        {
            this.Name = name;
            this.Color = color;
            this.speed = speed;
        }

        public void Render(DrawingContext drawingContext, int cameraPosition)
        {
            throw new NotImplementedException();
        }

        public void ChangeAcceleration()
        {
            this.acceleration = speed * RandomUtil.nextDouble(0.7, 1.3);
        }

    }
}
