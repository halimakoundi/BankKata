namespace BankKata.Src.Model
{
    public partial class BankAccount
    {
        private IDateProvider _dateProvider;
        private readonly TransactionRepository _transactionRepo;

        public BankAccount(IDateProvider dateProvider, TransactionRepository transactionRepo)
        {
            this._dateProvider = dateProvider;
            _transactionRepo = transactionRepo;
        }

        public void Deposit(decimal amount)
        {
            var transaction = new Transaction(amount, _dateProvider.TodayAsString());
            _transactionRepo.Save(transaction);
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
