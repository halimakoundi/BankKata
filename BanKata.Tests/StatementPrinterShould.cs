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
            var  statement = new Statement();

            _statementPrinter.Print(statement);

            _console.Received().PrintLine("| date       | credit  | debit  | balance |");
        }

    }
}
