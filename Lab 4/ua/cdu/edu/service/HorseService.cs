using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.horses = RandomUtil.randomHorses(5);
        }

        public void UpdateState()
        {
            horses.ForEach(horse => horse.UpdateState());
        }
    }
}
