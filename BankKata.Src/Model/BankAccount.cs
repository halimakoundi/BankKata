using System;
using System.Linq;
using BankKata.Src.Model.Presentation;
using BankKata.Src.Repositories;

namespace BankKata.Src.Model
{
    public class BankAccount
    {
        private readonly TransactionRepo _transactionRepo;
        private readonly IPrintStatement _printingPrintStatement;

        public BankAccount(TransactionRepo transactionRepo, IPrintStatement printingPrintStatement)
        {
            _transactionRepo = transactionRepo;
            _printingPrintStatement = printingPrintStatement;
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
            _transactionRepo.PrintStatementWith(_printingPrintStatement);
        }
    }
}
