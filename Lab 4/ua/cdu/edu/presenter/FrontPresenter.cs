using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.service;
using Lab_4.ua.cdu.edu.view;

using System;
using System.Windows;

namespace Lab_4.ua.cdu.edu
{
    public class FrontPresenter
    {
        private static readonly int SECOND = 1000;

        private bool raceInProgress;

        private readonly RenderService renderer;
        private readonly HorseService horseService;
        private readonly BetService betService;
        private readonly HorseView startUpHorseView;
        private readonly BetView betView;

        public FrontPresenter(RenderService renderer, HorseService horseService, BetService betService, HorseView startUpHorseView, BetView betView)
        {
            this.renderer = renderer;
            this.horseService = horseService;
            this.betService = betService;
            this.startUpHorseView = startUpHorseView;
            this.betView = betView;
            Init();
        }

        private void Init()
        {
            renderer.RenderFrame();
            betView.Render(betService.Balance);
            startUpHorseView.RenderHorseInfo(horseService.Horses);
            startUpHorseView.RenderHorseSelection(horseService.Horses);
        }

        public async void StartRace()
        {
            if (!raceInProgress)
            {
                horseService.StartRace();
                raceInProgress = true;
                await SchedulerExecutor.schedule(NextStage, SECOND / Config.FPS);
                raceInProgress = false;

                betService.RecalculateBalance(horseService.GetWinnerHorse());
                betView.Render(betService.Balance);
                betService.Reset();
            }
        }

        private bool NextStage()
        {
            bool raceOver = horseService.UpdateState();
            renderer.RenderFrame();


            return raceOver;
        }

        public void ResetRace()
        {
            if (!raceInProgress)
            {
                horseService.Reset();
                renderer.RenderFrame();
            }
        }

        public void NextHorse()
        {
            renderer.TargetHorse = horseService.NextHorse(renderer.TargetHorse);
        }

        public void PreviousHorse()
        {
            renderer.TargetHorse = horseService.PreviousHorse(renderer.TargetHorse);
        }

        public void ProcessBet()
        {
            if (!raceInProgress)
            {
                try
                {
                    Bet bet = betView.Bind();
                    betService.Bet(bet);
                    betView.Render(betService.Balance);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
