using BankKata.Src.Repositories;

namespace BankKata.Src.Model
{
    public class BankAccount
    {
        private readonly TransactionRepo _transactionRepo;

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
