using BankKata.Src;
using NSubstitute;
using NUnit.Framework;
namespace BanKata.Tests
{
    public class StatementPrinterShould
    {
        private IConsole _console;
        private StatementPrinter _statementPrinter;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _statementPrinter = new StatementPrinter(_console);

        }

        [Test]
        public void print_header()
        {
            var statement = new Statement();

            _statementPrinter.Print(statement);

            _console.Received().PrintLine("| date       | credit  | debit  | balance |");
        }


        [Test]
        public void print_transaction_in_reversed_order()
        {
            var statement = new Statement();
            statement.Add(new Transaction(1000m, "01/08/2016"));
            statement.Add(new Transaction(-250m, "03/13/2016"));

            _statementPrinter.Print(statement);
            
            Received.InOrder(() =>
            {
                _console.PrintLine("| date       | credit  | debit  | balance |");
                _console.PrintLine("| 03/13/2016 | | 250.00 | 750.00 |");
                _console.PrintLine("| 01/08/2016 | 1000.00 | | 1000.00 |");
            });
        }


    }
}
