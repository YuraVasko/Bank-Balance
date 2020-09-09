using Interlogic.Bank.Balance.AccountAgregate.Events;
using System.Collections.Generic;

namespace Interlogic.Bank.Balance.EventSource
{
    public interface IEventStore
    {
        public void AddEvents(IReadOnlyList<BalanceChangedEvent> events);

        public IReadOnlyList<BalanceChangedEvent> GetEvents();
    }
}
