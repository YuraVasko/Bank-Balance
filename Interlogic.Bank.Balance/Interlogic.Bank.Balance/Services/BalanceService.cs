using Interlogic.Bank.Balance.Events;
using System;
using System.Collections.Generic;

namespace Interlogic.Bank.Balance.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly List<BalanceChangedEvent> _balanceChangedEvents;

        public BalanceService()
        {
            _balanceChangedEvents = new List<BalanceChangedEvent>();
        }

        public int GetBalance()
        {
            int balance = 0;
            _balanceChangedEvents.ForEach(e =>
            {
                if (e is MoneyInserted)
                    balance += e.Amount;
                else if (e is MoneyWithdrawed)
                    balance -= e.Amount;
            });

            return balance;
        }

        public void InsertMoney(int amount)
        {
            _balanceChangedEvents.Add(new MoneyInserted(amount));
        }

        public void WithdrawMoney(int amount)
        {
            int balance = GetBalance();
            if (amount > balance)
            {
                throw new ArgumentException(nameof(amount));
            }

            _balanceChangedEvents.Add(new MoneyWithdrawed(amount));
        }
    }
}
