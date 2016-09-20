using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public interface Transaction
    {
        string PrintWith(IPrintStatement printStatement);
        string Date { get; }
       decimal Amount { get;}
    }
}