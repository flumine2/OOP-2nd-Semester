using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab_4.ua.cdu.edu.service
{
    public class HorseService
    {
        private static readonly Stopwatch TIMER = new();

        private List<Horse> horses;

        public List<Horse> Horses
        {
            get => horses;
            private set
            {
                horses = value;
            }
        }

        public HorseService()
        {
            this.horses = RandomUtil.randomHorses(Config.HORSES_COUNT);
            setCoefficients();
        }

        private void setCoefficients()
        {
            double maxSpeed = horses.Select(horse => horse.Speed).Max();
            horses.ForEach(horse => horse.Coefficient = nextCoefficient(horse.Speed, maxSpeed));
        }

        private double nextCoefficient(double speed, double maxSpeed)
        {
            return Math.Max(3 * (maxSpeed - speed) + 1 + RandomUtil.nextDouble(-0.5, 0.5), Config.MIN_COEFFICIENT);
        }

        public bool UpdateState()
        {
            bool raceOver = true;
            foreach (Horse horse in horses)
            {
                if (!horse.Finished)
                {
                    raceOver = false;
                    horse.UpdateState(TIMER.Elapsed);
                }
            }
            if (raceOver)
            {
                TIMER.Stop();
            }

            return raceOver;
        }

        public int NextHorse(int current)
        {
            return (current + 1) % horses.Count;
        }

        public int PreviousHorse(int current)
        {
            int previous = current - 1;
            return previous < 0 ? horses.Count - 1 : previous % horses.Count;
        }

        public void Reset()
        {
            TIMER.Reset();
            horses.ForEach(horse => horse.Reset());
        }

        public void StartRace()
        {
            TIMER.Start();
        }

        public string Bet(Bet bet)
        {
            horses[bet.HorseIndex].Bet += bet.Amount;
            return horses[bet.HorseIndex].Name;
        }

        public Horse GetWinnerHorse()
        {
            return horses.Max();
        }
    }
}
