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
        private StatementPrinter _statementPrinter;

        [SetUp]
        public void SetUp()
        {
            _dateProvider = Substitute.For<IDateProvider>();
            _transactionRepo = Substitute.For<TransactionRepository>();
            _statementPrinter = Substitute.For<StatementPrinter>();
            _bankAccount = new BankAccount(_dateProvider, _transactionRepo, _statementPrinter);
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

        [Test]
        public void save_transaction_when_a_withdrawal_is_made()
        {
            var date = "06/10/2012";
            var amount = 10m;
            var transaction = new Transaction(-amount, date);
            _dateProvider.TodayAsString().Returns(date);

            _bankAccount.Withdrawal(amount);

            _dateProvider.Received().TodayAsString();
            _transactionRepo.Received().Save(transaction);
        }
        
        [Test]
        public void print_statement()
        {
            Statement statement = new Statement();

            _transactionRepo.AllTransactions().Returns(statement);

            _bankAccount.PrintStatement();

            _statementPrinter.Received().Print(statement);
        }
    }
}
