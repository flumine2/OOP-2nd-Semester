using Lab_4.Logic.Model;
using Lab_4.ua.cdu.edu.util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Logic.Services
{
    public class HorseService
    {
        public static Stopwatch TIMER = new();
        private List<Horse> horses;

        public List<Horse> Horses
        {
            get => horses;
            private set 
            {
                horses = value;
            }
        }

        public HorseService()
        {
            this.horses = RandomUtil.randomHorses(5);
        }

        public void GetNextFrameData()
        {
            TIMER.Start();
            foreach (var horse in Horses)
            {
                horse.ChangeAcceleration();
            }
        }
    }
}
