using System.Linq;
using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;
using BankKata.Src.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class BankAccountShould
    {
        private TransactionRepo _transactionRepo;
        private Visitor _printingVisitor;
        private BankAccount _account;
        private Printer _console;
        private string _date = "21/08/2016";
        private decimal _amount = 20m;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<Printer>();
            _transactionRepo = Substitute.For<TransactionRepo>(_console);
            _printingVisitor = Substitute.For<StatementPrinter>();
            _account = new BankAccount(_transactionRepo, _printingVisitor);
        }


        [Test]
        public void store_deposit()
        {
            _account.Deposit(_amount, _date);

            _transactionRepo.Received().Save(new Deposit(_amount, _date));
        }


        [Test]
        public void store_withdrawal()
        {
            _account.Withdrawal(_amount,_date);

            _transactionRepo.Received().Save(new Withdrawal(_amount, _date));
        }

        [Test]
        public void print_statement()
        {
            _account.PrintStatement();

            _transactionRepo.Received().Accept(_printingVisitor);
        }
    }
}
