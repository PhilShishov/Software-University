using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
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
