namespace Interlogic.Bank.Balance.AccountAgregate.Errors
{
    public abstract class AccountDomainError
    {
        public string ErrorMessage { get; }

        public AccountDomainError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
