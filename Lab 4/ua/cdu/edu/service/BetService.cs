using Lab_4.ua.cdu.edu.exception;
using Lab_4.ua.cdu.edu.model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        private Dictionary<string, int> bets = new Dictionary<string, int>();

        public void Bet(int amount, string horseName) 
        {
            if (balance - amount < 0) 
            {
                throw new TransactionException($"No enough money to finish a transaction. Provided: {balance}. Required: {amount}");
            }
            balance -= amount;

            if (bets.ContainsKey(horseName)) 
            {
                bets[horseName] = bets[horseName] + amount;
            }
            else 
            {
                bets[horseName] = amount;
            }
        }

        public void RecalculateBalance(Horse winnerHorse) 
        {
            if (bets.ContainsKey(winnerHorse.Name)) 
            {
                balance += (int) Math.Round(bets[winnerHorse.Name] * winnerHorse.Coefficient);
            }
        }

        public void Reset() 
        {
            bets.Clear();
        }
    }
}
