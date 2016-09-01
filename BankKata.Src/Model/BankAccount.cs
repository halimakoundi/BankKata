using System;
using BankKata.Src.Model.Presentation;
using BankKata.Src.Repositories;

namespace BankKata.Src.Model
{
    public class BankAccount
    {
        private readonly TransactionRepo _transactionRepo;
        private readonly Visitor _printingVisitor;

        public BankAccount(TransactionRepo transactionRepo, Visitor printingVisitor)
        {
            _transactionRepo = transactionRepo;
            _printingVisitor = printingVisitor;
        }

        public void Deposit(decimal amount, string date)
        {
            _transactionRepo.Save(new Deposit(amount, date));
        }

        public void Withdrawal(decimal amount, string date)
        {
            _transactionRepo.Save(new Withdrawal(amount, date));
        }

        public void PrintStatement()
        {
            _transactionRepo.Statement().PrintWith(_printingVisitor);
        }
    }
}
