using BankKata.Src.Infrastructure;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;
using BankKata.Src.Repositories;
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
            var lineToPrint = _statementPrinter.Print(new Deposit(500.00m, "31/08/2016"));
            Assert.That(lineToPrint,Is.EqualTo("31/08/2016 || 500.00 || || "));
        }

        [Test]
        public void print_withdrawal_transaction()
        {
           var lineToPrint = _statementPrinter.Print(new Withdrawal(150.00m, "31/08/2016"));
            Assert.That(lineToPrint, Is.EqualTo("31/08/2016 || || 150.00 || "));
        }


        [Test]
        public void print_statement_line()
        {
            _statementPrinter.Print(new StatementLine(new Withdrawal(10m, "31/08/2016"), 390.00m));

            _console.Received().PrintLine("31/08/2016 || || 10.00 || 390.00");
        }

    }
}
