
namespace P05_TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TeamworkProjects
    {

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
        static void Main()
        {
            int teamCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('-');

                string creatorName = input[0];
                string teamName = input[1];

                //трябва да проверим дали такъв тийм вече не съществува:
                bool isTeamNameExist = teams.Any(x => x.Name == teamName);
                bool isCreatorNameExist = teams.Any(x => x.CreatorName == creatorName);

                if (isTeamNameExist == false && isCreatorNameExist == false)
                {
                    Team team = new Team(teamName, creatorName);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
                else if (isTeamNameExist)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (isCreatorNameExist)
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] splitedInput = input
                    .Split("->");

                string user = splitedInput[0];
                string teamName = splitedInput[1];

                //проверяваме дали такъв тийм съществува:
                bool isTeamExist = teams.Any(x => x.Name == teamName);
                bool isAlreadyMember = teams.Any(x => x.Members.Contains(user) || x.CreatorName == user);

                if (isTeamExist == false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (isAlreadyMember)
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                if (isTeamExist && isAlreadyMember == false)
                {
                    //трябва да намерим точно кой тийм ни трябва, неговият индекс в списъка с тиймове:
                    int indexOfTeam = teams.FindIndex(x => x.Name == teamName);
                    //добавяме юзъра към въпросния тийм:
                    teams[indexOfTeam].Members.Add(user);
                }
            }

            List<Team> teamsWithMembers = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.Name)
                .ToList();

            List<Team> teamsWithoutMembers = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var team in teamsWithMembers)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine("- " + team.CreatorName);
                Console.WriteLine(string.Join(Environment.NewLine, team.Members.OrderBy(x => x).Select(x => $"-- {x}")));
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsWithoutMembers)
            {
                Console.WriteLine(team.Name);
            }

        }
    }
}
