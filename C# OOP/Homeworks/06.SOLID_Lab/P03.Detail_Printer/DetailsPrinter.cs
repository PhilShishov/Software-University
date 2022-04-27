
namespace P03.DetailPrinter
{
    using System.Collections.Generic;
    using System.Linq;

    using P03.Detail_Printer;
    using P03.Detail_Printer.Contracts;

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

