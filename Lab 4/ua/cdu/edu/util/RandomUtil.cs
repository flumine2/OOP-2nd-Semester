using Lab_4.ua.cdu.edu.model;

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

        private static byte nextByte()
        {
            return (byte)nextInt(0, 255);
        }

        private static char nextChar()
        {
            return (char)nextInt(65, 90);
        }

        private static string nextString(int length)
        {
            return new string(Enumerable.Range(0, length)
                .Select(i => nextChar())
                .ToArray());
        }

        private static Color nextColor()
        {
            return Color.FromRgb(nextByte(), nextByte(), nextByte());
        }

        public static List<Horse> randomHorses(int count)
        {
            return Enumerable.Range(0, count)
                .Select((x, index) => nextHorse(index + 1))
                .ToList();
        }

        private static Horse nextHorse(int startPosition)
        {
            return new Horse
                (
                    name: nextString(7),
                    speed: nextInt(5, 11),
                    color: nextColor(),
                    startPosition: startPosition
                );
        }
    }
}
