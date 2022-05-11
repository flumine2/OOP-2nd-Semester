using Lab_4.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.Logic.Model
{
    class Horse : IRender
    {
        public string Name { get; private set; }
        public string Color { get; private set; }
        public TimeSpan Time { get; private set; }
        private int speed;
        private double acceleration;

        public Horse()
        {
            Random random = new();
            speed = random.Next(5, 11);
        }

        public void Render(DrawingContext drawingContext, int cameraPosition)
        {
            throw new NotImplementedException();
        }

        public async Task ChangeAcceleration()
        {
            Console.WriteLine("1 " + Thread.CurrentThread.ManagedThreadId);
            await Task.Run(()=> 
            {
                Random random = new();
                Console.WriteLine("2 " + Thread.CurrentThread.ManagedThreadId);
                double coef = random.NextDouble();
                while (coef < 0.7)
                {
                    coef = random.NextDouble();
                }
                acceleration = speed * coef;
            });
            Console.WriteLine("3 " + Thread.CurrentThread.ManagedThreadId);
        }

    }
}
