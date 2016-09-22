namespace BankKata.Src
{
    public class TransactionLine

    {
        public decimal Amount { get; }
        public string Date { get; }
        public decimal Balance { get; }

        public TransactionLine(string date, decimal amount, decimal balance)
        {
            Date = date;
            Amount = amount;
            Balance = balance;
        }
    }
}