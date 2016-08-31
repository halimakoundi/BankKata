using System;
using System.Collections.Generic;
using System.Linq;
using BankKata.Src.Clients;
using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public class Statement
    {
        private readonly Printer _printer;
        private readonly List<Transaction> _transactions =
                        new List<Transaction>();

        public Statement(Printer printer)
        {
            _printer = printer;
        }

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
            _printer.PrintLine("date || credit || debit || balance");
            foreach (var transaction in _transactions
                                            .OrderByDescending(x => DateTime.Parse(x.Date)))
            {
                var transactionLine = transaction.Accept(visitor);
                _printer.PrintLine("hello this is not printed for some reason :/ " + transactionLine);
            }
        }
    }
}