using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public class Withdrawal : Transaction
    {
        private readonly decimal _amount;

        public decimal Amount => - _amount;

        public string Date { get; }

        public Withdrawal(decimal amount, string date)
        {
            Date = date;
            _amount = amount;
        }

        public string Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}