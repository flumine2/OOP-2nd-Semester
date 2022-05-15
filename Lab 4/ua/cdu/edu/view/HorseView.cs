using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.service.animation;
using Lab_4.ua.cdu.edu.view;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.view
{
    public class HorseView : View<Horse>
    {

        private AnimationService<Horse> animationService;

        public HorseView(DrawingContext drawingContext) : base(drawingContext)
        {
            this.animationService = HorseAnimationService.Instance;
        }

        protected override void Render(double cameraPosition, Horse horse)
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
    }
}
