namespace P03.Detail_Printer.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IDetailsPrinter
    {
        void Print(IEmployee employee);

        bool IsMatch(IEmployee employee);

    }
}