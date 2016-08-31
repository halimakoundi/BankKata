using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class TransactionRepoShould
    {
        private TransactionRepo _repo;
        private Statement _transactions;
        private Printer _console;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<Printer>();
            _repo = new TransactionRepo(new Statement(_console));
        }

        [Test]
        public void save_deposit()
        {
            _repo.Save(new Deposit(100, "2012/03/12"));

            _transactions = _repo.Statement();

            Assert.That(_transactions.Count(), Is.Not.Zero);
        }

        [Test]
        public void save_withdrawal()
        {
            _repo.Save(new Withdrawal(20, "2012/05/12"));

            _transactions = _repo.Statement();

            Assert.That(_transactions.Count(), Is.EqualTo(1));
        }
    }
}