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

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}