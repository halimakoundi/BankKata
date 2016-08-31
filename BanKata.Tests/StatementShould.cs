using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class StatementShould
    {
        private Statement _statement;
        private StatementPrinter _statementPrinter;
        private Printer _console;

        [SetUp]
        public void Setup()
        {
            _statement = new Statement();
            _console = Substitute.For<Printer>();
            _statementPrinter = Substitute.For<StatementPrinter>(_console);
        }

        [Test]
        public void print_deposit()
        {
            var deposit = new Deposit(400m, "20/08/2016");
            _statement.Add(deposit);

            _statement.Accept(_statementPrinter);

            _statementPrinter.Received().Visit(deposit);
        }

        [Test]
        public void print_transactions_in_order()
        {
            var deposit = new Deposit(400m, "20/08/2016");
            _statement.Add(deposit);
            var withdrawal = new Withdrawal(10m, "31/08/2016");
            _statement.Add(withdrawal);

            _statement.Accept(_statementPrinter);

            Received.InOrder(() =>
            {
                _statementPrinter.Received().Visit(withdrawal);
                _statementPrinter.Received().Visit(deposit);
            });
        }
    }
}
