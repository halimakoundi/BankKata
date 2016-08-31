using System;
using System.Collections.Generic;
using System.Linq;
using BankKata.Src.Model.Presentation;

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

        public virtual void Accept(Visitor visitor)
        {
            foreach (var transaction in _transactions
                                            .OrderByDescending(x => DateTime.Parse(x.Date)))
            {
                transaction.Accept(visitor);
            }
        }
    }
}