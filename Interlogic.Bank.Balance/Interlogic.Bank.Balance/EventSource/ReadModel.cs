namespace Interlogic.Bank.Balance.EventSource
{
    public class ReadModel
    {
        public int Balance { get; set; }

        public int MaxWithdrawnAmount { get; set; }

        public int OperationsCount { get; set; }
    }
}
