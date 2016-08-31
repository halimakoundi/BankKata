namespace BankKata.Src
{
    public class TransactionRepo
    {
        private readonly Statement _statement = new Statement();

        public void Save(Transaction transaction)
        {
            _statement.Add(transaction);
        }

        public Statement Statement()
        {
            return _statement;
        }
    }
}