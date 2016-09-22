using BankKata.Src;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {

        [Test]
        public void save_transaction()
        {
            var transactionRepo = new TransactionRepository();
            var date = "01/10/2012";
            var amount = 150m;

            transactionRepo.Save(new Transaction(amount, date));

            var transactions =  transactionRepo.AllTransactions();
            Assert.That(transactions.Count(), Is.EqualTo(1));
        }
    }
}
