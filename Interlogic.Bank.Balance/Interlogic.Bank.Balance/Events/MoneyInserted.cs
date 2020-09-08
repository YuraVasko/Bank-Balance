namespace Interlogic.Bank.Balance.Events
{
    public class MoneyInserted : BalanceChangedEvent
    {
        public MoneyInserted(int amount) : base(amount) { }
    }
}
