namespace Interlogic.Bank.Balance.Services
{
    public interface IBalanceService
    {
        void InsertMoney(int amount);

        void WithdrawMoney(int amount);

        int GetBalance();
    }
}
