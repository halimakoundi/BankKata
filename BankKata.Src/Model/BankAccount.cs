namespace BankKata.Src.Model
{
    public partial class BankAccount
    {
        private IDateProvider _dateProvider;
        private readonly TransactionRepository _transactionRepo;
        private readonly StatementPrinter _statementPrinter;

        public BankAccount(IDateProvider dateProvider,
                            TransactionRepository transactionRepo,
                            StatementPrinter statementPrinter)
        {
            _dateProvider = dateProvider;
            _transactionRepo = transactionRepo;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(decimal amount)
        {
            var transaction = new Transaction(amount, _dateProvider.TodayAsString());
            _transactionRepo.Save(transaction);
        }

        public void Withdrawal(decimal amount)
        {

            var transaction = new Transaction(-amount, _dateProvider.TodayAsString());
            _transactionRepo.Save(transaction);
        }

        public void PrintStatement()
        {
            _statementPrinter.Print(_transactionRepo.AllTransactions());
        }
    }
}
