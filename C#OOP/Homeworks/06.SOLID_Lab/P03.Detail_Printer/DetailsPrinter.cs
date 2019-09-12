using P03.Detail_Printer;
using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        public void PrintDetails(IEmployee employee)
        {
            var printers = new List<IDetailsPrinter>()
            {
                new PrintEmployee(),
                new PrintManager()
            };

            printers.First(d => d.IsMatch(employee)).Print(employee);
        }
    }
}

