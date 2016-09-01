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
        public readonly List<Transaction> _transactions =
                        new List<Transaction>();

        public Statement(Printer printer)
        {
            _printer = printer;
        }

        public virtual void PrintWith(Visitor visitor)
        {
            _printer.PrintLine("date || credit || debit || balance");
            var orderedTransactions = GetOrderedTransactions();
            var balance = _transactions.Sum(x => x.Amount);

            orderedTransactions.ForEach(transaction =>
            {
                _printer.PrintLine(transaction.Accept(visitor) + balance.ToString("00.00"));
                balance -= transaction.Amount;

            });
        }

        public List<Transaction> GetOrderedTransactions()
        {
            return _transactions.OrderByDescending(x => DateTime.Parse(x.Date))
                .ToList();
        }
        
    }
}