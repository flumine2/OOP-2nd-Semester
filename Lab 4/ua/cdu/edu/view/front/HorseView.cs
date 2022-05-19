﻿using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.service.animation;
using Lab_4.ua.cdu.edu.view;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.view
{
    public class HorseView : FrontView<Horse>
    {
        private AnimationService<Horse> animationService;
        private double cameraPosition;
        private DataGrid dataGrid;

        public HorseView(DrawingContext drawingContext, double cameraPosition, DataGrid dataGrid) : base(drawingContext)
        {
            this.animationService = HorseAnimationService.Instance;
            this.cameraPosition = cameraPosition;
            this.dataGrid = dataGrid;
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

        public override void Render(List<Horse> horses)
        {
            base.Render(horses);

            dataGrid.ItemsSource = horses;
        }
    }
}
