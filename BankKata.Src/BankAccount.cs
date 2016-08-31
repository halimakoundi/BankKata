namespace BankKata.Src
{
    public class BankAccount
    {
        private TransactionRepo _transactionRepo;

        public BankAccount(TransactionRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public void Deposit(decimal amount, string date)
        {
            _transactionRepo.Save(new Deposit(amount, date));
        }

        public void Withdrawal(decimal amount, string date)
        {
            _transactionRepo.Save(new Withdrawal(amount, date));
        }

        public void PrintStatement()
        {
            
        }
    }
}
