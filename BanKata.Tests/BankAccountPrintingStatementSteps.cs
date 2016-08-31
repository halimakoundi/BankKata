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

        [Given(@"A client makes a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(decimal amount, string date)
        {
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
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the client would see ""(.*)""")]
        public void ThenTheClientWouldSee(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
