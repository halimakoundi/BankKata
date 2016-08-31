namespace BankKata.Src.Model
{
    public class Deposit : Transaction
    {
        public Deposit(decimal amount, string date)
        {
            Amount = amount;
            Date = date;
        }

        public decimal Amount { get; }

        public string Date { get; }
    }
}