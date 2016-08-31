namespace BankKata.Src.Model.Presentation
{
    public interface Visitor
    {
        string Visit(Withdrawal withdrawal);
        string Visit(Deposit deposit);
    }
}