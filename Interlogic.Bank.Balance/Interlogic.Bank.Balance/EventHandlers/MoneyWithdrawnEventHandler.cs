using Interlogic.Bank.Balance.AccountAgregate.Events;
using Interlogic.Bank.Balance.EventSource;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Interlogic.Bank.Balance.EventHandlers
{
    public class MoneyWithdrawnEventHandler : INotificationHandler<MoneyWithdrawn>
    {
        private readonly ReadModel _readModel;

        public MoneyWithdrawnEventHandler(ReadModel readModel)
        {
            _readModel = readModel;
        }

        public Task Handle(MoneyWithdrawn notification, CancellationToken cancellationToken)
        {
            _readModel.Balance -= notification.Amount;
            _readModel.OperationsCount++;
            _readModel.MaxWithdrawnAmount = _readModel.MaxWithdrawnAmount < notification.Amount 
                ? notification.Amount 
                : _readModel.MaxWithdrawnAmount;
            return Task.CompletedTask;
        }
    }
}
