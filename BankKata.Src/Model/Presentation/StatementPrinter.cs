namespace BankKata.Src.Model.Presentation
{
    public class StatementPrinter : Visitor
    {
        public void Visit(Withdrawal withdrawal)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(Deposit deposit)
        {
            throw new System.NotImplementedException();
        }
    }
}