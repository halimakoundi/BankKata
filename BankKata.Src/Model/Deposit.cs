namespace BankKata.Src.Model
{
    public class Deposit : Transaction
    {
        private readonly decimal _amount;
        private readonly string _date;

        public Deposit(decimal amount, string date)
        {
            _amount = amount;
            _date = date;
        }
    }
}