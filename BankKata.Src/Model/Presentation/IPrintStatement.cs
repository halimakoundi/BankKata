using BankKata.Src.Repositories;

namespace BankKata.Src.Model.Presentation
{
    public interface IPrintStatement
    {
        string Print(Withdrawal withdrawal);
        string Print(Deposit deposit);
        void Print(StatementLine statementLine);
        void PrintHeader();
    }
}