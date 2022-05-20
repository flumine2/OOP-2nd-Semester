using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.service.animation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab_4.ua.cdu.edu.view
{
    public class HorseView : FrontView<Horse>
    {
        private AnimationService<Horse> animationService;
        private double cameraPosition;
        private DataGrid horseInfo;
        private ComboBox horseSelection;

        public HorseView(DrawingContext drawingContext, double cameraPosition) : base(drawingContext)
        {
            this.animationService = HorseAnimationService.Instance;
            this.cameraPosition = cameraPosition;
        }

        public HorseView(DataGrid horseInfo, ComboBox horseSelection) : base(null)
        {
            this.horseInfo = horseInfo;
            this.horseSelection = horseSelection;
        }

        protected override void Render(Horse horse)
        {
            List<ImageSource> animation = animationService.animate(horse);
            drawingContext.DrawImage(
                animation[horse.State],
                new Rect
                (
                    horse.Position.X - cameraPosition,
                    horse.Position.Y,
                    Config.HorseSize.Width,
                    Config.HorseSize.Height
                )
            );
        }

        public void RenderHorseInfo(List<Horse> horses) 
        {
            horseInfo.ItemsSource = horses;
        }

        public void RenderHorseSelection(List<Horse> horses) 
        {
            horseSelection.ItemsSource = horses
                .Select(horse => GenerateHorseChoseBoxItem(horse))
                .ToList();
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
                                Width = Config.SELECTION_WIDTH,
                                Height = Config.SELECTION_HEIGHT
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
