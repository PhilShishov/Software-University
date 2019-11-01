using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Program
    {
        public static void Main()
        {
            string name = "Ivan";
            var documents = new List<string>();

            documents.Add("edno");
            documents.Add("dve");

            var manager = new Manager(name, documents);
            //var employee = new Employee(name);

            var printer = new DetailsPrinter();

            printer.PrintDetails(manager);
            //printer.PrintDetails(employee);
        }
    }
}
