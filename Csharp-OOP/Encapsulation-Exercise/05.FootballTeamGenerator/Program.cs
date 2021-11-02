using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Team> teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(';');
                string teamName = string.Empty;
                string playerName = string.Empty;
                try
                {
                    switch (commandArgs[0])
                    {
                        case "Team":
                            Team currentTeam = new Team(commandArgs[1]);
                            teams.Add(currentTeam);
                            break;
                        case "Add":
                            teamName = commandArgs[1];
                            if (teams.FirstOrDefault(t => t.Name == teamName) != null)
                            {
                                playerName = commandArgs[2];
                                int endurance = int.Parse(commandArgs[3]);
                                int sprint = int.Parse(commandArgs[4]);
                                int dribble = int.Parse(commandArgs[5]);
                                int passing = int.Parse(commandArgs[6]);
                                int shootig = int.Parse(commandArgs[7]);
                                Player currentPlayer = new Player(playerName, endurance, sprint, dribble, passing, shootig);
                                teams.FirstOrDefault(t => t.Name == teamName).AddPlayer(currentPlayer);
                            }
                            else
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            break;
                        case "Remove":
                            teamName = commandArgs[1];
                            playerName = commandArgs[2];
                            teams.FirstOrDefault(t => t.Name == teamName).RemovePlayer(playerName);
                            break;
                        case "Rating":
                            teamName = commandArgs[1];
                            if (teams.FirstOrDefault(t => t.Name == teamName) != null)
                            {
                                Console.WriteLine($"{teamName} - {teams.FirstOrDefault(t => t.Name == teamName).Rating}");
                            }
                            else
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
