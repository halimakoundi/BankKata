using System;
using System.Collections.Generic;
using System.Linq;
using BankKata.Src.Model;

namespace BankKata.Src.Repositories
{
    public class TransactionRepo
    {
        private readonly Statement _statement;
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public TransactionRepo(Statement statement)
        {
            _statement = statement;
        }

        public void Save(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public virtual Statement Statement()
        {
            return _statement;
        }

        public List<Transaction> GetOrderedTransactions()
        {
            return _transactions.OrderByDescending(x => DateTime.Parse(x.Date))
                .ToList();
        }

        public int Count()
        {
            return _transactions.Count;
        }
    }
}