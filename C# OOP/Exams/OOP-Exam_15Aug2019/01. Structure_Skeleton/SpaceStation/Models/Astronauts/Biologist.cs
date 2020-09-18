namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Biologist : Astronaut
    {
        private const double INITIAL_OXYGEN = 70;

        public Biologist(string name) 
            : base(name, INITIAL_OXYGEN)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 >= 0)
            {
                this.Oxygen -= 5;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
