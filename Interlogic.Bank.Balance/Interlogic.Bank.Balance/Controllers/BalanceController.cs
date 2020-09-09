using Interlogic.Bank.Balance.AccountAgregate;
using Interlogic.Bank.Balance.EventSource;
using Interlogic.Bank.Balance.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interlogic.Bank.Balance.Controllers
{
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IEventStore _eventStore;

        public BalanceController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpPost("/withdraw/money")]
        public IActionResult WithdrawMoney(WithdrawMoneyRequest request)
        {
            try
            {
                Account account = new Account(_eventStore.GetEvents());
                account.WithdrawMoney(request.Amount);
                _eventStore.AddEvents(account.Changes);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("/insert/money")]
        public IActionResult InsertMoney(InsertMoneyRequest request)
        {
            Account account = new Account(_eventStore.GetEvents());
            account.InsertMoney(request.Amount);
            _eventStore.AddEvents(account.Changes);
            return Ok();
        }

        [HttpGet("/balance")]
        public IActionResult GetBalance()
        {
            Account account = new Account(_eventStore.GetEvents());
            return Ok(account.Balance);
        }
    }
}
