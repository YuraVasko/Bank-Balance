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
                Apply((dynamic)e);
            });
        }

        private void Apply(MoneyTopUp e)
        {
            Balance += e.Amount;
        }

        private void Apply(MoneyWithdrawn e)
        {
            Balance -= e.Amount;
        }

        public void InsertMoney(int amount)
        {
            Balance += amount;

            var producedEvent = new MoneyTopUp(amount);
            Apply(producedEvent);
            _changes.Add(producedEvent);
        }

        public void WithdrawMoney(int amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException(nameof(amount));
            }

            var producedEvent = new MoneyWithdrawn(amount);
            Apply(producedEvent);
            _changes.Add(producedEvent);
        }

    }
}
