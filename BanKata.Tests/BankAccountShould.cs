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
        private Statement _statement;
        private Visitor _printingVisitor;
        private BankAccount _account;
        private Printer _console;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<Printer>();
            _statement = Substitute.For<Statement>(_console);
            _transactionRepo = Substitute.For<TransactionRepo>(_statement);
            _printingVisitor = Substitute.For<StatementPrinter>();
            _account = new BankAccount(_transactionRepo, _printingVisitor);
        }

        [Test]
        public void retrieve_statement_and_print_it()
        {
            _transactionRepo.Statement().Returns(_statement);

            _account.PrintStatement();

            Received.InOrder(() =>
            {
                _transactionRepo.Statement();
                _statement.PrintWith(_printingVisitor);
            });
        }
    }
}
