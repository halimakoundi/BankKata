using System.Collections.Generic;
using System.Linq;

namespace BankKata.Src
{
    public class Statement
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public int Count()
        {
            return _transactions.Count;
        }

        public IEnumerable<TransactionLine>  TransactionLines()
        {
            var runningBalance = 0m;

            return _transactions.Select(x => new TransactionLine(x.Date(), x.Amount(), runningBalance += x.Amount()));
        }
    }
}