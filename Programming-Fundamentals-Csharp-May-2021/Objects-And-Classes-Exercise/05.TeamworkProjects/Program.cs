using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<Team> allTeams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();

                bool ifTeamExist = allTeams.Select(t => t.TeamName).Contains(teamInfo[1]);
                bool ifMemberExist = allTeams.Any(t => t.Members.Contains(teamInfo[0]));

                if (!ifTeamExist && !ifMemberExist)
                {
                    allTeams.Add(new Team(teamInfo[1], teamInfo[0]));
                    Console.WriteLine($"Team {teamInfo[1]} has been created by {teamInfo[0]}!");
                }

                if (ifTeamExist)
                {
                    Console.WriteLine($"Team {teamInfo[1]} was already created!");
                }

                if (ifMemberExist)
                {
                    Console.WriteLine($"{teamInfo[0]} cannot create another team!");
                }

            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] inputArgs = input.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                bool ifMemberExist = allTeams.Any(t => t.Members.Contains(inputArgs[0]));
                bool ifTeamExist = allTeams.Any(t => t.TeamName == inputArgs[1]);

                if (!ifMemberExist && ifTeamExist)
                {
                    foreach (var team in allTeams)
                    {
                        if (inputArgs[1] == team.TeamName)
                        {
                            team.Members.Add(inputArgs[0]);
                            break;
                        }
                    }
                }

                if (ifMemberExist)
                {
                    Console.WriteLine($"Member {inputArgs[0]} cannot join team {inputArgs[1]}!");
                }

                if (!ifTeamExist)
                {
                    Console.WriteLine($"Team {inputArgs[1]} does not exist!");
                }

                input = Console.ReadLine();
            }

            allTeams = allTeams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).ToList();

            List<Team> disbandedTeams = new List<Team>();

            foreach (var team in allTeams)
            {
                if (team.Members.Count > 1)
                {
                    Console.WriteLine(team.TeamName);
                    Console.WriteLine($"- {team.Members[0]}");

                    team.Members.RemoveAt(0);
                    team.Members.Sort();

                    for (int i = 0; i < team.Members.Count;  i++)
                    {
                        Console.WriteLine($"-- {team.Members[i]}");
                    }
                }
                else if (team.Members.Count == 1)
                {
                    disbandedTeams.Add(new Team(team.TeamName, team.Members.ToString()));
                }
            }

            Console.WriteLine($"Teams to disband:");

            disbandedTeams = disbandedTeams.OrderBy(x => x.TeamName).ToList();

            foreach (var disbanded in disbandedTeams)
            {
                Console.WriteLine(disbanded.TeamName);
            }
        }

        class Team
        {
            public string TeamName { get; set; }

            public List<string> Members { get; set; }

            public Team(string teamName, string member)
            {
                TeamName = teamName;
                Members = new List<string>();
                Members.Add(member);
            }


        }
    }
}
