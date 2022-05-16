using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_4.ua.cdu.edu.service
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
            TIMER.Start();
            this.horses = RandomUtil.randomHorses(Config.HORSES_COUNT);
        }

        public bool UpdateState()
        {
            bool raceOver = true;
            foreach (Horse horse in horses) 
            {
                if (!horse.Finished) 
                {
                    raceOver = false;
                    horse.UpdateState();
                }
            }
            if (raceOver) 
            {
                TIMER.Stop();
            }
            horses.Sort();

            return raceOver;
        }

        public int NextHorse(int current) 
        {
            return (current + 1) % horses.Count;
        }

        public int PreviousHorse(int current)
        {
            int previous = current - 1;
            return previous < 0 ? horses.Count - 1 : previous % horses.Count;
        }

        public void Reset() 
        {
            for (int i = 0; i < horses.Count; i++) 
            {
                horses[i].Finished = false;
                horses[i].Position = new Point(0, horses[i].Position.Y);
            }
        }
    }
}
