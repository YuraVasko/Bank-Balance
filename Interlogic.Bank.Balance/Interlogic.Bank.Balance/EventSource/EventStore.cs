using Interlogic.Bank.Balance.Events;
using System.Collections.Generic;

namespace Interlogic.Bank.Balance.EventSource
{
    public class EventStore : IEventStore
    {
        private readonly List<BalanceChangedEvent> _balanceChangedEvents;

        public EventStore()
        {
            _balanceChangedEvents = new List<BalanceChangedEvent>();
        }

        public void AddEvent(BalanceChangedEvent @event)
        {
            _balanceChangedEvents.Add(@event);
        }

        public IEnumerable<BalanceChangedEvent> GetEvents() => _balanceChangedEvents;
    }
}
