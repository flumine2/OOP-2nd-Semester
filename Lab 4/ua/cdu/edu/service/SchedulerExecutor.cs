using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.ua.cdu.edu.service
{
    public delegate bool SchedulerTask();
    public class SchedulerExecutor
    {
        public static async void schedule(SchedulerTask task, int delay) 
        {
            while (!task())
            {
                await Task.Delay(delay);
            };
        }
    }
}
