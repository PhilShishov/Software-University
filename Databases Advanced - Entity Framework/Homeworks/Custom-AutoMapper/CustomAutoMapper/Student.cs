using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAutoMapper
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address address { get; set; }
    }
}
