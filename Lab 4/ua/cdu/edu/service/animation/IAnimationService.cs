using System.Collections.Generic;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.service.animation
{
    public interface IAnimationService<T>
    {
        List<ImageSource> Animate(T item);
    }
}
