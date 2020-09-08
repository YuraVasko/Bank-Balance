using Interlogic.Bank.Balance.Models;
using Interlogic.Bank.Balance.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interlogic.Bank.Balance.Controllers
{
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpPost("/withdraw/money")]
        public IActionResult WithdrawMoney(WithdrawMoneyRequest request)
        {
            try
            {
                _balanceService.WithdrawMoney(request.Amount);
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
            _balanceService.InsertMoney(request.Amount);
            return Ok();
        }

        [HttpGet("/balance")]
        public IActionResult GetBalance()
        {
            int balance = _balanceService.GetBalance();
            return Ok(balance);
        }
    }
}
