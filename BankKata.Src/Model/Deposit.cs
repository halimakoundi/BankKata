using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public class Deposit : Transaction
    {
        public decimal Amount { get; }
        public string Date { get; }

        public Deposit(decimal amount, string date)
        {
            Amount = amount;
            Date = date;
        }

        public string Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}