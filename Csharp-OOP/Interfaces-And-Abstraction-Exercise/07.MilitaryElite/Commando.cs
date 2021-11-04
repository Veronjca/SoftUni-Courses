using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string firstName, string lastName, string id, decimal salary, string corps) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            if (this.Missions.Count > 0)
            {
                return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Missions:{Environment.NewLine}{String.Join(Environment.NewLine, this.Missions)}";
            }
            
             return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Missions:";
        }
    }
}
