namespace BankKata.Src
{
    public class StatementPrinter
    {
        private readonly IConsole _console;

        public StatementPrinter(IConsole console)
        {
            _console = console;
        }

        public virtual void Print(Statement statement)
        {
            _console.PrintLine("| date       | credit  | debit  | balance |");
        }
    }
}