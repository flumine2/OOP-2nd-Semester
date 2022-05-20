using Lab_4.ua.cdu.edu.model.bind;
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
    public class Horse : PropertyChangedNotifier, IComparable<Horse>
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public int State { get; private set; }

        public TimeSpan Time { get; private set; }

        public Point Position { get; set; }
        public double Speed { get; set; }

        public double Coefficient { get; set; }
        public bool Finished { get; set; }

        private int bet;
        public int Bet {
            get => bet;
            set
            {
                bet = value;
                OnPropertyChanged("Bet");
            }
        }

        public Horse(string name, Color color, double speed, int startPosition)
        {
            Name = name;
            Color = color;
            this.Speed = speed;
            Position = GetInitialPosition(startPosition);
        }

        private Point GetInitialPosition(int startPosition) 
        {
            return new Point(0, 160 + (startPosition - 1) * Config.HorseSize.Height / 2);
        }

        public void UpdateState(TimeSpan timeSpan)
        {
            Time = timeSpan;
            if (Position.X > Config.TRACK_LENGTH)
            {
                Finished = true;
                State = 0;
            }
            else
            {
                State = (State + 1) % Config.STATES_COUNT;
            }
            Position = new Point(Position.X + ChangeSpeed(), Position.Y);

            base.OnPropertyChanged("Time");
            base.OnPropertyChanged("Position");
            base.OnPropertyChanged("Finished");
            base.OnPropertyChanged("Coeficient");
        }

        private double ChangeSpeed()
        {
            return Speed * RandomUtil.nextDouble(0.7, 1.3);
        }

        public void Reset() 
        {
            Finished = false;
            Bet = 0;
            Position = new Point(0, Position.Y);
        }

        public int CompareTo(Horse other)
        {
            return -Time.CompareTo(other.Time);
        }
    }
}
