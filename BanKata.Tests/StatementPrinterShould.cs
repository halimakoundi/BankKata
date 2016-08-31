using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class StatementPrinterShould
    {
        private Printer _console;
        private StatementPrinter _statementPrinter;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<Printer>();
            _statementPrinter = new StatementPrinter(_console);
        }

        [Test]
        public void print_deposit_transaction()
        {
            _statementPrinter.Visit(new Deposit(500.00m, "31/08/2016"));

            _console.Received().PrintLine("31/08/2016 || || 500.00 || ");
        }

        [Test]
        public void print_withdrawal_transaction()
        {
            _statementPrinter.Visit(new Withdrawal(150.00m, "31/08/2016"));

            _console.Received().PrintLine("31/08/2016 || 150.00 || || ");
        }
    }
}
