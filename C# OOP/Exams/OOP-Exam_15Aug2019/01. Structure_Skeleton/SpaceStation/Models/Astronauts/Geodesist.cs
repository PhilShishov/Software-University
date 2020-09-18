namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Geodesist : Astronaut
    {
        private const double INITIAL_OXYGEN = 50;

        public Geodesist(string name)
            : base(name, INITIAL_OXYGEN)
        {
        }

    }
}
