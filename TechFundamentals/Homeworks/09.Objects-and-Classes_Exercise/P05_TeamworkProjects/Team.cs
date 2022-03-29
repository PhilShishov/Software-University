
namespace P05_TeamworkProjects
{
    using System.Collections.Generic;

    public class Team
    {
        public Team(string name, string creatorName)
        {
            Name = name;
            CreatorName = creatorName;
            Members = new List<string>();
        }

        public string Name { get; set; }

        public string CreatorName { get; set; }

        public List<string> Members { get; set; }

    }
}
