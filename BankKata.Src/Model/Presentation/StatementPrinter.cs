using System;

namespace BankKata.Src.Model.Presentation
{
    public class StatementPrinter : Visitor
    {
        public string Visit(Withdrawal withdrawal)
        {
            return $"{withdrawal.Date} || || {Math.Abs(withdrawal.Amount).ToString("00.00")} || ";
        }

        public string Visit(Deposit deposit)
        {
            return $"{deposit.Date} || {deposit.Amount.ToString("00.00")} || || ";
        }
    }
}