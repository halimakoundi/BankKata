using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public class Withdrawal : Transaction
    {
        public decimal Amount { get; }
        public string Date { get; }

        public Withdrawal(decimal amount, string date)
        {
            Date = date;
            Amount = amount;
        }

        public string Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}