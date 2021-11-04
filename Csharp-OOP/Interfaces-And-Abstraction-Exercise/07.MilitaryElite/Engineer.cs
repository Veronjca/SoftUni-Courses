using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            if (this.Repairs.Count > 0)
            {
                return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Repairs:{Environment.NewLine}{String.Join(Environment.NewLine, this.Repairs)}";
            }
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Repairs:";

        }
    }
}
