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
        private static readonly string[] NAMES = 
        {
            "Lola", "Maks", "Jane", "Apple", "Mila", "John", "Victor", "Chance",
            "Bella", "Alex", "Lilly", "Alexia", "Fancy", "Sugar", "Lady", "Tucker",
            "Dakota", "Cash", "Daisy", "Spirit", "Cisco", "Annie", "Buddy", "Whiskey",
            "Blue", "Molly", "Ginger", "Gypsy", "Charlie", "Ranger", "Star", "Willow", "Lacey"
        };

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

        private static Color nextColor()
        {
            return Color.FromRgb(nextByte(), nextByte(), nextByte());
        }

        public static List<Horse> randomHorses(int count)
        {
            ISet<string> usedNames = new HashSet<string>();
            return Enumerable.Range(0, count)
                .Select((x, index) => nextHorse(index + 1, usedNames))
                .ToList();
        }

        private static Horse nextHorse(int startPosition, ISet<string> usedNames)
        {
            return new Horse
                (
                    name: nextName(usedNames),
                    speed: nextInt(Config.MIN_SPEED, Config.MAX_SPEED),
                    color: nextColor(),
                    startPosition: startPosition
                );
        }

        private static string nextName(ISet<string> usedNames) 
        {
            string generatedName = NAMES[nextInt(0, NAMES.Length - 1)];
            while (!usedNames.Add(generatedName)) 
            {
                generatedName = NAMES[nextInt(0, NAMES.Length - 1)];
            }

            return generatedName;
        }
    }
}
