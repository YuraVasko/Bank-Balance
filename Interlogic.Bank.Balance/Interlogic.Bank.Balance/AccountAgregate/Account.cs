using Interlogic.Bank.Balance.AccountAgregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interlogic.Bank.Balance.AccountAgregate
{
    public class Account
    {
        private List<BalanceChangedEvent> _changes;
        public int Balance { get; private set; }
        public IReadOnlyList<BalanceChangedEvent> Changes => _changes;

        public Account(IEnumerable<BalanceChangedEvent> events)
        {
            _changes = new List<BalanceChangedEvent>();
            events.ToList().ForEach(e =>
            {
                When((dynamic)e);
            });
        }

        public void InsertMoney(int amount) => Apply(new MoneyTopUp(amount));

        public void WithdrawMoney(int amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException(nameof(amount));
            }

            Apply(new MoneyWithdrawn(amount));
        }

        private void Apply(BalanceChangedEvent @event)
        {
            When((dynamic)@event);
            _changes.Add(@event);
        }

        private void When(MoneyTopUp e)
        {
            Balance += e.Amount;
        }

        private void When(MoneyWithdrawn e)
        {
            Balance -= e.Amount;
        }
    }
}
