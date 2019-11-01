namespace SpaceStation.Models.Mission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                var astronaut = astronauts.FirstOrDefault(a => a.CanBreath == true);

                if (astronaut == null)
                {
                    break;
                }

                var item = planet.Items.FirstOrDefault();

                if (item == null)
                {
                    break;
                }

                astronaut.Bag.Items.Add(item);
                astronaut.Breath();
                planet.Items.Remove(item);
            }
        }
    }
}
