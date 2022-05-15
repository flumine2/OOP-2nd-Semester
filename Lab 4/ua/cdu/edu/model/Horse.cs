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
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public TimeSpan Time { get; private set; }
        public int State { get; private set; }

        public Point Position { get; private set; }
        public bool Finished { get; private set; }

        private double speed;

        public Horse(string name, Color color, double speed, int startPosition)
        {
            this.Name = name;
            this.Color = color;
            this.speed = speed;
            this.Position = GetInitialPosition(startPosition);
        }

        private Point GetInitialPosition(int startPosition) 
        {
            return new Point(1600, 160 + (startPosition - 1) * Config.HorseSize.Height / 2);
        }

        public void UpdateState()
        {
            Time = HorseService.TIMER.Elapsed;
            if (Position.X > Config.TRACK_LENGTH) 
            {
                Finished = true;
            }
            State = (State + 1) % Config.STATES_COUNT;
            ChangeSpeed();
            Position = new Point(Position.X + ChangeSpeed(), Position.Y);
        }

        private double ChangeSpeed()
        {
            return speed * RandomUtil.nextDouble(0.7, 1.3);
        }
    }
}
