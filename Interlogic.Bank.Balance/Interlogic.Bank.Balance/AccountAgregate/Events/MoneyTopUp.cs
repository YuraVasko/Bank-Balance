namespace Interlogic.Bank.Balance.AccountAgregate.Events
{
    public class MoneyTopUp : BalanceChangedEvent
    {
        public MoneyTopUp(int amount) : base(amount) { }
    }
}
