using System.Text.RegularExpressions;
using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;
using BankKata.Src.Repositories;
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
        private Visitor _printingVisitor;

        [Given(@"A client makes a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(decimal amount, string date)
        {
            _console = Substitute.For<Printer>();
            _printingVisitor = new StatementPrinter();
            _transactionRepo = new TransactionRepo(_console);
            _account = new BankAccount(_transactionRepo, _printingVisitor);
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
        
        [Then(@"the client would see (.*)")]
        public void ThenTheClientWouldSee(string printedStatement)
        {
            
            Received.InOrder(() =>
            {
                foreach (var line in Regex.Split(printedStatement, "\n"))
                {
                    _console.PrintLine(line);
                }
            });
        }
    }
}
