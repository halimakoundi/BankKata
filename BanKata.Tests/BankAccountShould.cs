using BankKata.Src;
using BankKata.Src.Model;
using NSubstitute;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class BankAccountShould
    {
        private TransactionRepository _transactionRepo;
        private IDateProvider _dateProvider;
        private BankAccount _bankAccount;

        [SetUp]
        public void SetUp()
        {
            _dateProvider = Substitute.For<IDateProvider>();
            _transactionRepo = Substitute.For<TransactionRepository>();

            _bankAccount = new BankAccount(_dateProvider, _transactionRepo);
        }

        [Test]
        public void save_transaction_when_a_deposit_is_made()
        {
            var date = "01/10/2012";
            var amount = 12.34m;
            var transaction = new Transaction(amount, date);
            _dateProvider.TodayAsString().Returns(date);

            _bankAccount.Deposit(amount);

            _dateProvider.Received().TodayAsString();
            _transactionRepo.Received().Save(transaction);
        }
    }
}
