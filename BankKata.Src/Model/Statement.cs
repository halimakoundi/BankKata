using System.Collections.Generic;
using BankKata.Src.Clients;
using BankKata.Src.Model.Presentation;

namespace BankKata.Src.Model
{
    public class Statement
    {
        private readonly Printer _printer;
        public readonly List<Transaction> _transactions =
                        new List<Transaction>();

        public Statement(Printer printer)
        {
            _printer = printer;
        }
    }
}