namespace BankKata.Src
{
    public class TransactionRepository
    {
        private Statement _statement = new Statement();

        public virtual void Save(Transaction transaction)
        {
            _statement.Add(transaction);
        }

        public virtual Statement AllTransactions()
        {
            return _statement;
        }
    }
}