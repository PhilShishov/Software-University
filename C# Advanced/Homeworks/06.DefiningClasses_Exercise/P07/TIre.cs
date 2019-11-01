namespace P07
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tire
    {
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get; set; }
        public int Age { get; set; }

        //public int Age1 { get; set; }
        //public double Pressure1 { get; set; }
        //public int Age2 { get; set; }
        //public double Pressure2 { get; set; }
        //public int Age3 { get; set; }
        //public double Pressure3 { get; set; }
        //public int Age4 { get; set; }
        //public double Pressure4 { get; set; }

    }
}
