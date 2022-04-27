
namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public Manager(string name, List<string> documents)
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public List<string> Documents { get; set; }
    }
}
