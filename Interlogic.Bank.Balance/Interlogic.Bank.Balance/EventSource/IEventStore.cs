using Interlogic.Bank.Balance.Events;
using System.Collections.Generic;

namespace Interlogic.Bank.Balance.EventSource
{
    public interface IEventStore
    {
        public void AddEvent(BalanceChangedEvent @event);

        public IEnumerable<BalanceChangedEvent> GetEvents();
    }
}
