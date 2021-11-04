using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }

        public List<Private> Privates { get; set; }

        public override string ToString()
        {
            if (this.Privates.Count > 0)
            {
                return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}Privates:{Environment.NewLine}{String.Join(Environment.NewLine, this.Privates)}";
            }
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}Privates:";

        }
    }
}
