namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.Patients = new List<Patient>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public List<Patient> Patients { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(x => x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
