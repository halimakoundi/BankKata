using BankKata.Src.Clients;
using BankKata.Src.Model;
using BankKata.Src.Model.Presentation;
using NSubstitute;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class StatementPrinterShould
    {

        [Test]
        public void print_deposit_transaction()
        {
            var console = Substitute.For<Printer>();
            StatementPrinter statementPrinter = new StatementPrinter(console);

            statementPrinter.Visit(new Deposit(500.00m, "31/08/2016"));

            console.Received().PrintLine("31/08/2016 || || 500.00 || ");
        }
    }
}
