using BankKata.Src.Model;

namespace BankKata.Src.Repositories
{
    public class TransactionRepo
    {
        private readonly Statement _statement;

        public TransactionRepo(Statement statement)
        {
            _statement = statement;
        }

        public void Save(Transaction transaction)
        {
            _statement.Add(transaction);
        }

        public virtual Statement Statement()
        {
            return _statement;
        }
    }
}