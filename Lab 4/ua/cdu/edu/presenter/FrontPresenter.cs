using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.service;
using Lab_4.ua.cdu.edu.view;

using System;
using System.Windows;

namespace Lab_4.ua.cdu.edu
{
    public class FrontPresenter
    {
        private const int SECOND = 1000;

        private bool _raceInProgress;

        private readonly RenderService _renderer;
        private readonly HorseService _horseService;
        private readonly BetService _betService;
        private readonly HorseView _startUpHorseView;
        private readonly BetView _betView;

        public FrontPresenter(RenderService renderer, HorseService horseService, BetService betService, HorseView startUpHorseView, BetView betView)
        {
            _renderer = renderer;
            _horseService = horseService;
            _betService = betService;
            _startUpHorseView = startUpHorseView;
            _betView = betView;
            Init();
        }

        private void Init()
        {
            _renderer.RenderFrame();
            _betView.Render(_betService.Balance);
            _startUpHorseView.RenderHorseInfo(_horseService.Horses);
            _startUpHorseView.RenderHorseSelection(_horseService.Horses);
        }

        public async void StartRace()
        {
            if (!_raceInProgress)
            {
                _horseService.StartRace();
                _raceInProgress = true;
                await SchedulerExecutor.Schedule(NextStage, SECOND / Config.FPS);
                _raceInProgress = false;

                _betService.RecalculateBalance(_horseService.GetWinnerHorse());
                _betView.Render(_betService.Balance);
                _betService.Reset();
            }
        }

        private bool NextStage()
        {
            bool raceOver = _horseService.UpdateState();
            _renderer.RenderFrame();


            return raceOver;
        }

        public void ResetRace()
        {
            if (!_raceInProgress)
            {
                _horseService.Reset();
                _renderer.RenderFrame();
            }
        }

        public void NextHorse()
        {
            _renderer.TargetHorse = _horseService.NextHorse(_renderer.TargetHorse);
        }

        public void PreviousHorse()
        {
            _renderer.TargetHorse = _horseService.PreviousHorse(_renderer.TargetHorse);
        }

        public void ProcessBet()
        {
            if (!_raceInProgress)
            {
                try
                {
                    Bet bet = _betView.Bind();
                    _betService.Bet(bet);
                    _betView.Render(_betService.Balance);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
