﻿namespace MXGP.Models.Motorcycles
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SpeedMotorcycle : Motorcycle
    {
        private const double INITIAL_CUBIC = 125;
        private const int MIN_HORSEPOWER = 50;
        private const int MAX_HORSEPOWER = 69;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, INITIAL_CUBIC)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value < MIN_HORSEPOWER || value > MAX_HORSEPOWER)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                base.HorsePower = value;
            }
        }
    }
}
