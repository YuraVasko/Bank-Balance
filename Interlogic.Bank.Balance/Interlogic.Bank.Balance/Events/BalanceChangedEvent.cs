using System;

namespace Interlogic.Bank.Balance.Events
{
    public abstract class BalanceChangedEvent
    {
        public Guid Id { get; set; }
        
        public DateTime TransactionDateTime { get; set; }

        public int Amount { get; set; }

        public BalanceChangedEvent(int amount)
        {
            Id = Guid.NewGuid();
            TransactionDateTime = DateTime.Now;
            Amount = amount;
        }
    }
}
