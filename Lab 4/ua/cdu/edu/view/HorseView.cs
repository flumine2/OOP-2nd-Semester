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
            this.animationService = new HorseAnimationService();
        }

        protected override void Render(int cameraPosition, Horse horse)
        {
            List<ImageSource> animation = animationService.animate(horse);
            drawingContext.DrawImage(
                animation[0],
                new Rect
                (
                    horse.Position.X - cameraPosition,
                    horse.Position.Y,
                    animation[0].Width,
                    animation[0].Height
                )
            );
        }
    }
}
