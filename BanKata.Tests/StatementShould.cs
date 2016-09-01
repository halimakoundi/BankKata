//using BankKata.Src.Clients;
//using BankKata.Src.Model;
//using BankKata.Src.Model.Presentation;
//using NSubstitute;
//using NUnit.Framework;

//namespace BanKata.Tests
//{
//    [TestFixture]
//    public class StatementShould
//    {
//        private Statement _statement;
//        private StatementPrinter _statementPrinter;
//        private Printer _console;

//        [SetUp]
//        public void Setup()
//        {
//            _console = Substitute.For<Printer>();
//            _statement = new Statement(_console);
//            _statementPrinter = Substitute.For<StatementPrinter>();
//        }

//        [Test]
//        public void print_statement_header()
//        {
//            _statement.PrintWith(_statementPrinter);
//            _console.Received().PrintLine("date || credit || debit || balance");
//        }

//        [Test]
//        public void print_deposit()
//        {
//            var deposit = new Deposit(400m, "20/08/2016");
//            _statement.Add(deposit);

//            _statement.PrintWith(_statementPrinter);

//            _statementPrinter.Received().Visit(deposit);
//        }

//        [Test]
//        public void print_transactions_in_order()
//        {
//            var deposit = new Deposit(400m, "20/08/2016");
//            _statement.Add(deposit);
//            var withdrawal = new Withdrawal(10m, "31/08/2016");
//            _statement.Add(withdrawal);

//            _statement.PrintWith(_statementPrinter);

//            Received.InOrder(() =>
//            {
//                _statementPrinter.Received().Visit(withdrawal);
//                _statementPrinter.Received().Visit(deposit);
//            });
//        }

//        [Test]
//        public void print_statement_balance()
//        {
//            var deposit = new Deposit(400m, "20/08/2016");
//            _statement.Add(deposit);
//            var withdrawal = new Withdrawal(10m, "31/08/2016");
//            _statement.Add(withdrawal);

//            _statement.PrintWith(_statementPrinter);

//            Received.InOrder(() =>
//            {
//                _console.Received().PrintLine("date || credit || debit || balance");
//                _console.Received().PrintLine("31/08/2016 || || 10.00 || 390.00");
//                _console.Received().PrintLine("20/08/2016 || 400.00 || || 400.00");
//            });
//        }
//    }
//}
