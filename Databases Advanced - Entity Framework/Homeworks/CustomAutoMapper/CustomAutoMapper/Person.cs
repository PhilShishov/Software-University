using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAutoMapper
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address address { get; set; }
    }
}
