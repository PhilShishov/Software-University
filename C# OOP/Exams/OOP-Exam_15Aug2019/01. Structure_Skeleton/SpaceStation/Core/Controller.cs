namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private Mission mission;
        private Backpack bag;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.bag = new Backpack();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }            

            IAstronaut astronaut = null;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }

            this.astronautRepository.Add(astronaut);

            return $"Successfully added {astronaut.GetType().Name}: {astronaut.Name}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return $"Successfully added Planet: {planet.Name}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planetRepository.FindByName(planetName);

            var astrounauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();

            if (astrounauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }

            this.mission.Explore(planet, astrounauts);
            this.exploredPlanetsCount++;

            return $"Planet: {planet.Name} was explored! Exploration finished with {astrounauts.Where(a => a.CanBreath == false).Count()} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                return $"Astronaut {astronautName} doesn't exists!";
            }

            this.astronautRepository.Remove(astronaut);

            return $"Astronaut {astronaut.Name} was retired!";
        }
    }
}
