using Lab_4.Logic.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.util
{
    public static class RandomUtil
    {
        private static Random RANDOM = new Random();

        public static int nextInt(int min, int max) 
        {
            return RANDOM.Next(min, max);
        }

        public static double nextDouble(double min, double max)
        {
            return RANDOM.NextDouble() * (max - min) + min;
        }

        public static List<Horse> randomHorses(int count)
        {
            return Enumerable.Range(0, count)
                .Select(i => nextHorse())
                .ToList();
        }

        private static Horse nextHorse()
        {
            return new Horse
                (
                    name: nextString(7),
                    speed: RandomUtil.nextInt(5, 11),
                    color: nextColor()
                ) ;
        }

        private static Color nextColor() 
        {
            return Color.FromRgb(nextByte(), nextByte(), nextByte());
        }

        private static byte nextByte()
        {
            return (byte)nextInt(0, 255);
        }

        private static string nextString(int length)
        {
            return new string(Enumerable.Range(0, length)
                .Select(i => nextChar())
                .ToArray());
        }

        private static char nextChar() 
        {
            return (char)nextInt(65, 90);
        }
    }
}
