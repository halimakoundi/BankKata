using System.Collections.Generic;

namespace BankKata.Src.Model
{
    public class Statement
    {
        private readonly List<Transaction> _transactions =
                        new List<Transaction>();

        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public int Count()
        {
            return _transactions.Count;
        }
    }
}