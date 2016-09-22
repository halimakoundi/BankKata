using System;
using BankKata.Src;
using BankKata.Src.Model;
using NSubstitute;
using TechTalk.SpecFlow;

namespace BanKata.Tests
{
    [Binding]
    public class BankAccountPrintingStatementSteps
    {
        private BankAccount _bankAccount;
        private IDateProvider _dateProvider;
        private IConsole _console;
        private TransactionRepository _transactionRepo;
        private StatementPrinter _statementPrinter;

        [Given(@"A client makes a deposit of (.*) on ""(.*)""")]
        public void GivenAClientMakesADepositOfOn(Decimal amount, string date)
        {
            _console = Substitute.For<IConsole>();
            _dateProvider = Substitute.For<IDateProvider>();
            _transactionRepo = new TransactionRepository();
            _statementPrinter = new StatementPrinter();

            _dateProvider.TodayAsString().Returns(date);
            _bankAccount = new BankAccount(_dateProvider, _transactionRepo, _statementPrinter);

            _bankAccount.Deposit(amount);
        }

        [Given(@"a deposit of (.*) on ""(.*)""")]
        public void GivenADepositOfOn(Decimal amount, string date)
        {
            _dateProvider.TodayAsString().Returns(date);

            _bankAccount.Deposit(amount);
        }
        
        [Given(@"a withdrawal of (.*) on ""(.*)""")]
        public void GivenAWithdrawalOfOn(Decimal amount, string date)
        {
            _dateProvider.TodayAsString().Returns(date);

            _bankAccount.Withdrawal(amount);
        }
        
        [When(@"the client prints the bank statement")]
        public void WhenTheClientPrintsTheBankStatement()
        {
            _bankAccount.PrintStatement();
        }
        
        [Then(@"the client would see")]
        public void ThenTheClientWouldSee(Table table)
        {
            Received.InOrder(() =>
            {
                _console.PrintLine("| date       | credit  | debit  | balance |");
                _console.PrintLine("| 01/14/2012 |         | 500.00 | 2500.00 |");
                _console.PrintLine("| 01/13/2012 | 2000.00 |        | 3000.00 |");
                _console.PrintLine("| 01/10/2012 | 1000.00 |        | 1000.00 |");
            });
        }
    }
}
