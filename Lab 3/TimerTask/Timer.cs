using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_3.TimerTask
{
    delegate void MethodDelegate(string str);

    class Timer
    {
        public static void Start(int time, MethodDelegate method, string argument)
        {
            while (true)
            {
                Thread.Sleep(time);
                method(argument);
            }
        }
    }
}
