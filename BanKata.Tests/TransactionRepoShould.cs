﻿using BankKata.Src;
using NUnit.Framework;

namespace BanKata.Tests
{
    [TestFixture]
    public class TransactionRepoShould
    {
        private TransactionRepo _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new TransactionRepo();
        }

        [Test]
        public void save_deposit()
        {
            _repo.Save(new Deposit(100, "2012/03/12"));
            Statement transactions = _repo.Statement();
            Assert.That(transactions.Count(), Is.Not.Zero);
        }

    }
}