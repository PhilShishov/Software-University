namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Tire
    {
        public Tire(int year0, double pressure0, int year1, double pressure1, int year2, double pressure2, int year3, double pressure3)
        {
            this.Year0 = year0;
            this.Pressure0 = pressure0;
            this.Year1 = year1;
            this.Pressure1 = pressure1;
            this.Year2 = year2;
            this.Pressure2 = pressure2;
            this.Year3 = year3;
            this.Pressure3 = pressure3;
        }
        public int Year0 { get; set; }
        public double Pressure0 { get; set; }
        public int Year1 { get; set; }
        public double Pressure1 { get; set; }
        public int Year2 { get; set; }
        public double Pressure2 { get; set; }
        public int Year3 { get; set; }
        public double Pressure3 { get; set; }
    }
}
