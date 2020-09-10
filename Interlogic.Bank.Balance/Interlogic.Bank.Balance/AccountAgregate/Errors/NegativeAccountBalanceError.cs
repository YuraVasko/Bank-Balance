namespace Interlogic.Bank.Balance.AccountAgregate.Errors
{
    public class NegativeAccountBalanceError : AccountDomainError
    {
        public NegativeAccountBalanceError() : base("Account balance could not be negative") { }
    }
}
