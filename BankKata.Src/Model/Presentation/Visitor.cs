namespace BankKata.Src.Model.Presentation
{
    public interface Visitor
    {
        void Visit(Withdrawal withdrawal);
        void Visit(Deposit deposit);
    }
}