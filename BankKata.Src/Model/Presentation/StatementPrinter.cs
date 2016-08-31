using System;
using BankKata.Src.Clients;

namespace BankKata.Src.Model.Presentation
{
    public class StatementPrinter : Visitor
    {
        private readonly Printer _console;
        private readonly string PrinterHeader = "date || credit || debit || balance";

        public StatementPrinter(Printer console)
        {
            _console = console;
        }

        public void Visit(Withdrawal withdrawal)
        {
            _console.PrintLine($"{withdrawal.Date} || {withdrawal.Amount.ToString("00.00")} || || ");
        }

        public void Visit(Deposit deposit)
        {
            _console.PrintLine($"{deposit.Date} || || {deposit.Amount.ToString("00.00")} || ");
        }

        public void PrintHeader()
        {
            _console.PrintLine(PrinterHeader);
        }
    }
}