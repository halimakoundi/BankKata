using System;
using System.Text.RegularExpressions;
using BankKata.Src.Infrastructure;
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
        private IPrintStatement _printingPrintStatement;

        [Given(@"A client makes a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(decimal amount, string date)
        {
            _console = Substitute.For<Printer>();
            _printingPrintStatement = new StatementPrinter(_console);
            _transactionRepo = new TransactionRepo();
            _account = new BankAccount(_transactionRepo, _printingPrintStatement);
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
                foreach (var line in printedStatement.Split(new[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    _console.PrintLine(line);
                }
            });
        }
    }
}
