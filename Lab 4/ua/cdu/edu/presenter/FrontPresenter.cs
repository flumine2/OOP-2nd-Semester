using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab_4.ua.cdu.edu
{
    public class FrontPresenter
    {
        private static readonly int SECOND = 1000;

        private bool raceInProgress;

        private readonly RenderService renderer;
        private readonly HorseService horseService;

        public FrontPresenter(RenderService renderer, HorseService horseService)
        {
            this.renderer = renderer;
            this.horseService = horseService;
            renderer.RenderFrame();
        }

        public async void StartRace() 
        {
            if (!raceInProgress) 
            {
                raceInProgress = true;
                await SchedulerExecutor.schedule(NextStage, SECOND / Config.FPS);
                raceInProgress = false;
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

        public void GenerateHorseChoseBox(ComboBox comboBox)
        {
            List<ComboBoxItem> horsesData = new();

            foreach (Horse horse in horseService.Horses)
            {
                horsesData.Add(GenerateHorseChoseBoxItem(horse));
            }

            comboBox.Items.Clear();
            comboBox.ItemsSource = horsesData;
        }

        private ComboBoxItem GenerateHorseChoseBoxItem(Horse horse)
        {
            return new ComboBoxItem
            {
                Background = Brushes.Black,
                Content = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Children = {
                            new Rectangle
                            {
                                Fill = new SolidColorBrush(horse.Color),
                                Width = 20,
                                Height = 20
                            },
                            new Label
                            {
                                Content = horse.Name,
                                Foreground = Brushes.White
                            }
                        }
                }
            };
        }
    }
}
