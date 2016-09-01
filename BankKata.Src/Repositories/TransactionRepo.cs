using System;
using System.Collections.Generic;
using System.Linq;
using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Repositories
{
    public class TransactionRepo
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();
        private readonly Printer _printer;

        public TransactionRepo(Printer printer)
        {
            _printer = printer;
        }

        public void Save(Transaction transaction)
        {
            _transactions.Add(transaction);
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

        public void Accept(Visitor visitor)
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
    }
}