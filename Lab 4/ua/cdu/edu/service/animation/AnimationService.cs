using System.Collections.Generic;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.service.animation
{
    public interface AnimationService<T>
    {
        List<ImageSource> animate(T item);
    }
}
