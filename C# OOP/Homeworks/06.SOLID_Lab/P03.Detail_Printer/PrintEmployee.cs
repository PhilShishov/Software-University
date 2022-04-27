namespace P03.Detail_Printer
{
    using System;

    using P03.Detail_Printer.Contracts;
    using P03.DetailPrinter;

    public class PrintEmployee : IDetailsPrinter
    {
        public bool IsMatch(IEmployee employee)
        {
            if (employee is Employee)
            {
                return true;
            }

            return false;
        }

        public void Print(IEmployee employee)
        {
            Console.WriteLine(employee.Name);
        }
    }
}
