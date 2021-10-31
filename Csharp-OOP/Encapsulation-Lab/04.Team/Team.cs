using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam = new List<Person>();
        private List<Person> reserveTeam = new List<Person>();
        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        { 
            get => this.name;
            set => this.name = value;
        }
        public IReadOnlyCollection<Person> FirstTeam 
        {
            get => this.firstTeam.AsReadOnly();
        } 
        public IReadOnlyCollection<Person> ReserveTeam 
        {
            get => this.reserveTeam.AsReadOnly();
        } 

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this.firstTeam.Add(player);
            }
            else
            {
                this.reserveTeam.Add(player);
            }
        }
    }
}
