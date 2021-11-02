using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;

            }
        }

        public int Rating => this.players.Count == 0 ? 0 : (int)this.players.Average(p => p.SkillLevel);

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(player);
        }

       
    }
}
