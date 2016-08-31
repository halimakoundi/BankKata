using BankKata.Src;
using TechTalk.SpecFlow;

namespace BanKata.Tests
{
    [Binding]
    public class BankAccountPrintingStatementSteps
    {
        private BankAccount _account;

        [Given(@"A client makes a deposit of (.*) on (.*)(.*)")]
        public void GivenAClientMakesADepositOfOn(decimal amount, string date)
        {
            _account.Deposit(amount, date);
        }

        [Given(@"a deposit of (.*) on (.*)(.*)")]
        public void GivenADepositOfOn(int p0, string p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a withdrawal of (.*) on (.*)(.*)")]
        public void GivenAWithdrawalOfOn(int p0, string p1, int p2)
        {
            ScenarioContext.Current.Pending();
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
