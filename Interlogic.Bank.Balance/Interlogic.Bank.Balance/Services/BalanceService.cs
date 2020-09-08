using Interlogic.Bank.Balance.Events;
using Interlogic.Bank.Balance.EventSource;
using System;
using System.Linq;

namespace Interlogic.Bank.Balance.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IEventStore _eventStore;

        public BalanceService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public int GetBalance()
        {
            int balance = 0;
            var events = _eventStore.GetEvents().ToList();
            events.ForEach(e =>
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
            _eventStore.AddEvent(new MoneyInserted(amount));
        }

        public void WithdrawMoney(int amount)
        {
            int balance = GetBalance();
            if (amount > balance)
            {
                throw new ArgumentException(nameof(amount));
            }

            _eventStore.AddEvent(new MoneyWithdrawed(amount));
        }
    }
}
