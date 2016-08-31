using BankKata.Src;
using NSubstitute;
using TechTalk.SpecFlow;

namespace BanKata.Tests
{
    [Binding]
    public class BankAccountPrintingStatementSteps
    {
        private BankAccount _account;
        private TransactionRepo _transactionRepo;
        private Printer _console;

        [Given(@"A client makes a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(decimal amount, string date)
        {
            _console = Substitute.For<Printer>();
            _transactionRepo = new TransactionRepo();
            _account = new BankAccount(_transactionRepo);
            _account.Deposit(amount, date);
        }

        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenADepositOfOn(decimal amount, string date)
        {
            _account.Deposit(amount, date);
        }

        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(decimal amount, string date)
        {
            _account.Withdrawal(amount, date);
        }
        
        [When(@"the client prints the bank statement")]
        public void WhenTheClientPrintsTheBankStatement()
        {
            _account.PrintStatement();
        }
        
        [Then(@"the client would see ""(.*)""")]
        public void ThenTheClientWouldSee(string p0)
        {
            Received.InOrder(() =>
            {
                _console.PrintLine("date || credit || debit || balance");
                _console.PrintLine("14/01/2012 || || 500.00 || 2500.00");
                _console.PrintLine("13/01/2012 || 2000.00 || || 3000.00");
                _console.PrintLine("10/01/2012 || 1000.00 || || 1000.00");
            });
        }
    }
}
