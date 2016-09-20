using System;
using BankKata.Src.Infrastructure;
using BankKata.Src.Repositories;

namespace BankKata.Src.Model.Presentation
{
    public class StatementPrinter : IPrintStatement
    {
        private readonly Printer _printer;

        public StatementPrinter(Printer printer)
        {
            _printer = printer;
        }

        public void PrintHeader()
        {
            _printer.PrintLine("date || credit || debit || balance");
        }

        public string Print(Withdrawal withdrawal)
        {
            return $"{withdrawal.Date} || || {Math.Abs(withdrawal.Amount).ToString("00.00")} || ";
        }

        public string Print(Deposit deposit)
        {
            return $"{deposit.Date} || {deposit.Amount.ToString("00.00")} || || ";
        }

        public void Print(StatementLine statementLine)
        {
            _printer.PrintLine($"{statementLine.Transaction.PrintWith(this)}{statementLine.Balance.ToString("00.00")}");
        }
    }
}