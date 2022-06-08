using Lab_4.ua.cdu.edu.model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Lab_4.ua.cdu.edu.util
{
    public static class RandomUtil
    {
        private static readonly Random RANDOM = new();
        private static readonly string[] NAMES =
        {
            "Lola", "Maks", "Jane", "Apple", "Mila", "John", "Victor", "Chance",
            "Bella", "Alex", "Lilly", "Alexia", "Fancy", "Sugar", "Lady", "Tucker",
            "Dakota", "Cash", "Daisy", "Spirit", "Cisco", "Annie", "Buddy", "Whiskey",
            "Blue", "Molly", "Ginger", "Gypsy", "Charlie", "Ranger", "Star", "Willow", "Lacey"
        };

        public static int NextInt(int min, int max)
        {
            return RANDOM.Next(min, max);
        }

        public static double NextDouble(double min, double max)
        {
            return RANDOM.NextDouble() * (max - min) + min;
        }

        private static byte NextByte()
        {
            return (byte)NextInt(0, 255);
        }

        private static Color NextColor()
        {
            return Color.FromRgb(NextByte(), NextByte(), NextByte());
        }

        public static List<Horse> RandomHorses(int count)
        {
            ISet<string> usedNames = new HashSet<string>();
            return Enumerable.Range(0, count)
                .Select((x, index) => NextHorse(index + 1, usedNames))
                .ToList();
        }

        private static Horse NextHorse(int startPosition, ISet<string> usedNames)
        {
            return new Horse
                (
                    name: NextName(usedNames),
                    speed: NextInt(Config.MIN_SPEED, Config.MAX_SPEED),
                    color: NextColor(),
                    startPosition: startPosition
                );
        }

        private static string NextName(ISet<string> usedNames)
        {
            string generatedName = NAMES[NextInt(0, NAMES.Length - 1)];
            while (!usedNames.Add(generatedName))
            {
                generatedName = NAMES[NextInt(0, NAMES.Length - 1)];
            }

            return generatedName;
        }
    }
}
