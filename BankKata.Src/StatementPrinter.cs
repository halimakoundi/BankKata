using System.Collections.Generic;
using System.Linq;

namespace BankKata.Src
{
    public class StatementPrinter
    {
        private const string DateCreditDebitBalance = "| date       | credit  | debit  | balance |";
        private readonly IConsole _console;

        public StatementPrinter(IConsole console)
        {
            _console = console;
        }

        public virtual void Print(Statement statement)
        {
            _console.PrintLine(DateCreditDebitBalance);

            statement.TransactionLines()
                    .Reverse()
                    .ToList()
                    .ForEach(tl =>
                    {
                        _console.PrintLine($"| {tl.Date} | {TransactionAmount(tl.Amount)} | {tl.Balance.ToString("0.00")} |");
                    });
        }

        private string TransactionAmount(decimal transactionAmount)
        {
            return transactionAmount > 0 ? $"{transactionAmount.ToString("0.00")} |"
                : $"| {(-transactionAmount).ToString("0.00")}";
        }
    }

    public class TransactionLine

    {
        public decimal Amount { get; }
        public string Date { get; }
        public decimal Balance { get; }

        public TransactionLine(string date, decimal amount, decimal balance)
        {
            Date = date;
            Amount = amount;
            Balance = balance;
        }
    }
}