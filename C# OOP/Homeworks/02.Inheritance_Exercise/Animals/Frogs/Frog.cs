﻿namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
