namespace MilitaryElite.Models
{
    using MilitaryElite.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mi in this.missions)
            {
                sb.AppendLine($"  {mi.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
