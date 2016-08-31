namespace BankKata.Src
{
    public class Withdrawal : Transaction
    {
        private decimal _amount;
        private string _date;

        public Withdrawal(decimal amount, string date)
        {
            _date = date;
            _amount = amount;
        }
    }
}