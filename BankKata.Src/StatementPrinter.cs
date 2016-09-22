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
            PrintHeader();

            PrintLines(statement);
        }

        private void PrintLines(Statement statement)
        {
            statement.TransactionLines()
                .Reverse()
                .ToList()
                .ForEach(
                    tl =>
                    {
                        _console.PrintLine($"| {tl.Date} | {TransactionAmount(tl.Amount)} | {tl.Balance.ToString("0.00")} |");
                    });
        }

        private void PrintHeader()
        {
            _console.PrintLine(DateCreditDebitBalance);
        }

        private string TransactionAmount(decimal transactionAmount)
        {
            return transactionAmount > 0 ? $"{transactionAmount.ToString("0.00")} |"
                : $"| {(-transactionAmount).ToString("0.00")}";
        }
    }
}