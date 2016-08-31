using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public interface Transaction
    {
        string Accept(Visitor visitor);
        string Date { get; }
    }
}