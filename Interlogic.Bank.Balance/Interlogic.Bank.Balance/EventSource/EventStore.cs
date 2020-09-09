using Interlogic.Bank.Balance.AccountAgregate.Events;
using System.Collections.Generic;

namespace Interlogic.Bank.Balance.EventSource
{
    public class EventStore
    {
        private readonly List<BalanceChangedEvent> _balanceChangedEvents;

        public EventStore()
        {
            _balanceChangedEvents = new List<BalanceChangedEvent>();
        }

        public void AddEvents(IReadOnlyList<BalanceChangedEvent> events)
        {
            _balanceChangedEvents.AddRange(events);
        }

        public IReadOnlyList<BalanceChangedEvent> GetEvents() => _balanceChangedEvents;
    }
}
