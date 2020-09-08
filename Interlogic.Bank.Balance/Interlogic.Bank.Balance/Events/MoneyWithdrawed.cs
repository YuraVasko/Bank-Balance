namespace Interlogic.Bank.Balance.Events
{
    public class MoneyWithdrawed : BalanceChangedEvent
    {
        public MoneyWithdrawed(int amount) : base(amount) { }
    }
}
