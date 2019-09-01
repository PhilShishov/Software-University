namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.astronauts = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.astronauts.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.Count < this.Capacity)
            {
                astronauts.Add(astronaut);
            }            
        }

        public bool Remove(string name)
        {
            var astronaut = astronauts.FirstOrDefault(a => a.Name == name);
            bool isRemoved = false;

            if (astronaut != null)
            {
                astronauts.Remove(astronaut);
                isRemoved = true;
            }

            return isRemoved;
        }

        public Astronaut GetOldestAstronaut()
        {
            var astronaut = astronauts.OrderByDescending(a => a.Age).FirstOrDefault();

            return astronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            var astronaut = astronauts.FirstOrDefault(a => a.Name == name);

            return astronaut;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astr in this.astronauts)
            {
               stringBuilder.AppendLine(astr.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
