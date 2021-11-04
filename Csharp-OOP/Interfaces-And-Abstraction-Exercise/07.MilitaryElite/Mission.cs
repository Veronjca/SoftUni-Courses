using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Mission 
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string CodeName { get; set; }
        public string State { get; set; } = String.Empty;

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
