using Lab_4.ua.cdu.edu.exception;
using Lab_4.ua.cdu.edu.model;

using System;
using System.Collections.Generic;

namespace Lab_4.ua.cdu.edu.service
{
    public class BetService
    {
        private int balance = Config.INITIAL_BALANCE;
        public int Balance
        {
            get => balance;
            private set => balance = value;
        }

        private readonly HorseService horseService;
        private readonly Dictionary<string, int> bets = new();

        public BetService(HorseService horseService)
        {
            this.horseService = horseService;
        }

        public void Bet(Bet bet)
        {
            if (balance - bet.Amount < 0)
            {
                throw new TransactionException($"No enough money to finish a transaction. Provided: {balance}. Required: {bet.Amount}");
            }
            string targetHorse = horseService.Bet(bet);
            balance -= bet.Amount;

            if (bets.ContainsKey(targetHorse))
            {
                bets[targetHorse] = bets[targetHorse] + bet.Amount;
            }
            else
            {
                bets[targetHorse] = bet.Amount;
            }
        }

        public void RecalculateBalance(Horse winnerHorse)
        {
            if (bets.ContainsKey(winnerHorse.Name))
            {
                balance += (int)Math.Round(bets[winnerHorse.Name] * winnerHorse.Coefficient);
            }
        }

        public void Reset()
        {
            bets.Clear();
        }
    }
}
