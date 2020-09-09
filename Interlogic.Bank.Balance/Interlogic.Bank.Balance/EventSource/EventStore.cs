using Interlogic.Bank.Balance.AccountAgregate.Events;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Interlogic.Bank.Balance.EventSource
{
    public class EventStore
    {
        private readonly List<BalanceChangedEvent> _balanceChangedEvents;
        private readonly IMediator _mediator;

        public EventStore(IMediator mediator)
        {
            _balanceChangedEvents = new List<BalanceChangedEvent>();
            _mediator = mediator;
        }

        public void AddEvents(IReadOnlyList<BalanceChangedEvent> events)
        {
            _balanceChangedEvents.AddRange(events);
            events.ToList().ForEach(e =>
            {
                _mediator.Publish(e);
            });
        }

        public IReadOnlyList<BalanceChangedEvent> GetEvents() => _balanceChangedEvents;
    }
}
