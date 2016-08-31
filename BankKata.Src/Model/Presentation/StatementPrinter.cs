using BankKata.Src.Clients;

namespace BankKata.Src.Model.Presentation
{
    public class StatementPrinter : Visitor
    {
        private readonly Printer _console;

        public StatementPrinter(Printer console)
        {
            _console = console;
        }

        public void Visit(Withdrawal withdrawal)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(Deposit deposit)
        {
            _console.PrintLine($"{deposit.Date} || || {deposit.Amount.ToString("00.00")} || ");
        }
    }
}