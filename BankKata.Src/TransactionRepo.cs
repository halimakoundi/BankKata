namespace BankKata.Src
{
    public class TransactionRepo
    {
        private Statement _statement;

        public void Save(Transaction deposit)
        {
            throw new System.NotImplementedException();
        }

        public Statement Statement()
        {
            return _statement;
        }
    }
}