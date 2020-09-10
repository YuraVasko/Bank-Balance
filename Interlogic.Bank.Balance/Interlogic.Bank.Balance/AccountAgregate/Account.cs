using CSharpFunctionalExtensions;
using Interlogic.Bank.Balance.AccountAgregate.Errors;
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

        public Result<int> TopUpMoney(int amount)
        {
            Apply(new MoneyTopUp(amount));
            return Result.Success(Balance);
        }

        public Result<int, AccountDomainError> WithdrawMoney(int amount)
        {
            if (amount > Balance)
            {
                return Result.Failure<int, AccountDomainError>(new NegativeAccountBalanceError());
            }

            Apply(new MoneyWithdrawn(amount));
            return Result.Success<int, AccountDomainError>(Balance);
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