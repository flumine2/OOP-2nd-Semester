using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.service.animation
{
    public interface AnimationService<T>
    {
        List<ImageSource> animate(T item);
    }
}
