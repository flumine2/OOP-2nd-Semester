using System.Threading.Tasks;

namespace Lab_4.ua.cdu.edu.service
{
    public delegate bool SchedulerTask();
    public class SchedulerExecutor
    {
        public static async Task schedule(SchedulerTask task, int delay)
        {
            while (!task())
            {
                await Task.Delay(delay);
            };
        }
    }
}
