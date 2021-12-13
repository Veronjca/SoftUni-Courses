using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player current = this.roster.FirstOrDefault(p => p.Name == name);
            if (current != null)
            {
                this.roster.Remove(current);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player current = this.roster.FirstOrDefault(p => p.Name == name);
            current.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player current = this.roster.FirstOrDefault(p => p.Name == name);
            current.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] removed = this.roster.Where(p => p.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);
            return removed;

        }

        public string Report()
        {
            return $"Players in the guild: {this.Name}{Environment.NewLine}{String.Join(Environment.NewLine, this.roster)}";
        }
    }
}
