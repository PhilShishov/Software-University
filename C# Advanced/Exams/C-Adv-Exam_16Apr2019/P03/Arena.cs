namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var gladiator = gladiators.Where(g => g.Name == name).FirstOrDefault();
            gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            var gladiator = gladiators.OrderByDescending(g => g.GetStatPower()).FirstOrDefault();
            return gladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            var gladiator = gladiators.OrderByDescending(g => g.GetWeaponPower()).FirstOrDefault();
            return gladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            var gladiator = gladiators.OrderByDescending(g => g.GetTotalPower()).FirstOrDefault();
            return gladiator;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.Count} gladiators are participating.");

            return sb.ToString().TrimEnd();
        }
    }

}
