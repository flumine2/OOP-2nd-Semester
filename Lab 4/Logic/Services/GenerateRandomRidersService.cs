using Lab_4.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.Logic.Services
{
    class GenerateRandomRidersService
    {
        private static PropertyInfo[] properties = typeof(Colors).GetProperties();
        private static Color[] colors = properties.Select(x => (Color)x.GetValue(null, null)).ToArray();

        public static List<Horse> GenerateRandomRiders(int count)
        {
            List<Horse> horses = new();
            for (int i = 0; i < count; i++)
            {
                horses.Add(GenerateRandomHorse());
            }
            return horses;
        }

        public static Horse GenerateRandomHorse()
        {
            throw new NotImplementedException(); 
        }
    }
}
