using Lab_4.ua.cdu.edu.service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_4.ua.cdu.edu
{
    public class FrontPresenter
    {
        private static readonly int SECOND = 1000;
        private static readonly int FPS = 50;

        private readonly RenderService renderer;
        private readonly HorseService horseService;

        public FrontPresenter(RenderService renderer, HorseService horseService)
        {
            this.renderer = renderer;
            this.horseService = horseService;
            renderer.RenderFrame();
        }

        public void StartRace() 
        {
            SchedulerExecutor.schedule(NextStage, SECOND / FPS);
        }

        private bool NextStage() 
        {
            bool raceOver = horseService.UpdateState();
            renderer.RenderFrame();

            return raceOver;
        }
    }
}
