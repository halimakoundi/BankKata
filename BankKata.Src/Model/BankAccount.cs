namespace BankKata.Src.Model
{
    public class BankAccount
    {
        private IDateProvider _dateProvider;

        public BankAccount(IDateProvider dateProvider)
        {
            this._dateProvider = dateProvider;
        }

        public void Deposit(decimal p0)
        {
            throw new System.NotImplementedException();
        }

        public void Withdrawal(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void PrintStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}
