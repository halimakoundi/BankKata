using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public interface Transaction
    {
        void Accept(Visitor visitor);
        string Date { get; }
    }
}