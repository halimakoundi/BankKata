using System;
using System.Collections.Generic;
using System.Linq;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Repositories
{
    public class TransactionRepo
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

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

        public void PrintStatementWith(IPrintStatement statementLinePrinter)
        {
            statementLinePrinter.PrintHeader();

            PrintStatementLines(statementLinePrinter);
        }

        private void PrintStatementLines(IPrintStatement statementLinePrinter)
        {
            ToStatementLines()
                .OrderByDescending(sl => DateTime.Parse(sl.Transaction.Date))
                .ToList()
                .ForEach(sl => sl.Accept(statementLinePrinter));
        }

        private IEnumerable<StatementLine> ToStatementLines()
        {
            var bal = 0m;
            var statementLines = _transactions
                .Select(t =>
                {
                    bal += t.Amount;
                    var statementLine = new StatementLine(t, bal);
                    return statementLine;
                });
            return statementLines;
        }
    }

    public class StatementLine
    {
        public StatementLine(Transaction transaction, decimal balance)
        {
            Transaction = transaction;
            Balance = balance;
        }

        public Transaction Transaction { get; }

        public decimal Balance { get; }

        public void Accept(IPrintStatement printStatement)
        {
            printStatement.Print(this);
        }
    }
}