using CSharpFunctionalExtensions;
using Interlogic.Bank.Balance.AccountAgregate;
using Interlogic.Bank.Balance.EventSource;
using Interlogic.Bank.Balance.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Interlogic.Bank.Balance.Controllers
{
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly EventStore _eventStore;
        private readonly ReadModel _readModel;

        public BalanceController(EventStore eventStore, ReadModel readModel)
        {
            _eventStore = eventStore;
            _readModel = readModel;
        }

        [HttpPost("/withdraw/money")]
        public IActionResult WithdrawMoney(WithdrawMoneyRequest request)
        {
            Account account = new Account(_eventStore.GetEvents());
            var result = account.WithdrawMoney(request.Amount);
            if (result.IsFailure)
            {
                return BadRequest(result.Error.ErrorMessage);
            }

            _eventStore.AddEvents(account.Changes);
            return Ok(result.Value);
        }

        [HttpPost("/insert/money")]
        public IActionResult InsertMoney(InsertMoneyRequest request)
        {
            Account account = new Account(_eventStore.GetEvents());
            var result = account.InsertMoney(request.Amount);
            _eventStore.AddEvents(account.Changes);
            return Ok(result.Value);
        }

        [HttpGet("/balance")]
        public IActionResult GetBalance()
        {
            return Ok(_readModel.Balance);
        }

        [HttpGet("/max/withdrawn/amount")]
        public IActionResult GetMaxWithdrawnAmount()
        {
            return Ok(_readModel.MaxWithdrawnAmount);
        }

        [HttpGet("/operations/count")]
        public IActionResult GetOperationsCount()
        {
            return Ok(_readModel.OperationsCount);
        }
    }
}
