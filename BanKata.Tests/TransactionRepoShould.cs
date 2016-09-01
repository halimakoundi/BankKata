using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;
using BankKata.Src.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class TransactionRepoShould
    {
        private TransactionRepo _repo;
        private Printer _console;
        private Visitor _statementPrinter;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<Printer>();
            _statementPrinter = Substitute.For<StatementPrinter>();
            _repo = new TransactionRepo(_console);
        }

        [Test]
        public void save_deposit()
        {
            _repo.Save(new Deposit(100, "2012/03/12"));

            Assert.That(_repo.Count(), Is.EqualTo(1));
        }

        [Test]
        public void save_withdrawal()
        {
            _repo.Save(new Withdrawal(20, "2012/05/12"));

            Assert.That(_repo.Count(), Is.EqualTo(1));
        }

        [Test]
        public void print_repo_header()
        {
            _repo.Accept(_statementPrinter);
            _console.Received().PrintLine("date || credit || debit || balance");
        }

        [Test]
        public void print_deposit()
        {
            var deposit = new Deposit(400m, "20/08/2016");
            _repo.Save(deposit);

            _repo.Accept(_statementPrinter);

            _statementPrinter.Received().Visit(deposit);
        }

        [Test]
        public void print_transactions_in_order()
        {
            var deposit = new Deposit(400m, "20/08/2016");
            _repo.Save(deposit);
            var withdrawal = new Withdrawal(10m, "31/08/2016");
            _repo.Save(withdrawal);

            _repo.Accept(_statementPrinter);

            Received.InOrder(() =>
            {
                _statementPrinter.Received().Visit(withdrawal);
                _statementPrinter.Received().Visit(deposit);
            });
        }

        [Test]
        public void print_repo_balance()
        {
            var deposit = new Deposit(400m, "20/08/2016");
            _repo.Save(deposit);
            var withdrawal = new Withdrawal(10m, "31/08/2016");
            _repo.Save(withdrawal);

            _repo.Accept(_statementPrinter);

            Received.InOrder(() =>
            {
                _console.Received().PrintLine("date || credit || debit || balance");
                _console.Received().PrintLine("31/08/2016 || || 10.00 || 390.00");
                _console.Received().PrintLine("20/08/2016 || 400.00 || || 400.00");
            });
        }

    }
}