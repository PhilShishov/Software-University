namespace P03.Detail_Printer
{
    using System;

    using P03.Detail_Printer.Contracts;
    using P03.DetailPrinter;

    public class PrintManager : IDetailsPrinter
    {
        public bool IsMatch(IEmployee employee)
        {
            if (employee is Manager)
            {
                return true;
            }

            return false;
        }

        public void Print(IEmployee employee)
        {
            var manager = employee as Manager;

            Console.WriteLine(manager.Name);
            Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        }
    }
}
