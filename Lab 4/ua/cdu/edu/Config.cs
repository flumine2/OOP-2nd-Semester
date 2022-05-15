using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_4.ua.cdu.edu
{
    public static class Config
    {
        public static readonly double TRACK_LENGTH = 38400;
        public static readonly double PIXELS_PER_DIP = 96;
        public static readonly byte STATES_COUNT = 12;
        public static readonly int MIN_SPEED = 10;
        public static readonly int MAX_SPEED = 12;

        public static readonly Size BackgroundSize = new Size(800, 820);
        public static readonly Size HorseSize = new Size(130, 90);
    }
}
