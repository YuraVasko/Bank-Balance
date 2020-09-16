namespace Interlogic.Bank.Balance.AccountAgregate.Events
{
    public class MoneyWithdrawn : BalanceChangedEvent
    {
        public MoneyWithdrawn(int amount) : base(amount) { }
    }
}
