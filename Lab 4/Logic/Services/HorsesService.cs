using Lab_4.Logic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Logic.Services
{
    class HorsesService
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

        public HorsesService()
        {
            Horses = GenerateRandomRidersService.GenerateRandomRiders(5);
        }

        public async void GetNextFrameData()
        {
            List<Task> tasks = new();
            TIMER.Start();
            foreach (var horse in Horses)
            {
                tasks.Add(horse.ChangeAcceleration());
            }
            await Task.WhenAll(tasks);
        }
    }
}
