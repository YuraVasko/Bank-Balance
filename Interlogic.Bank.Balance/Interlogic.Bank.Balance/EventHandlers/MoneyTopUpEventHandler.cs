using Interlogic.Bank.Balance.AccountAgregate.Events;
using Interlogic.Bank.Balance.EventSource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Interlogic.Bank.Balance.EventHandlers
{
    public class MoneyTopUpEventHandler : INotificationHandler<MoneyTopUp>
    {
        private readonly ReadModel _readModel;

        public MoneyTopUpEventHandler(ReadModel readModel)
        {
            _readModel = readModel;
        }

        public Task Handle(MoneyTopUp notification, CancellationToken cancellationToken)
        {
            _readModel.Balance += notification.Amount;
            _readModel.OperationsCount++;
            return Task.CompletedTask;
        }
    }
}
