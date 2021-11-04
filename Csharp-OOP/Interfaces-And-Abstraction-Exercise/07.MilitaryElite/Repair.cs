using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Repair 
    {
        public Repair(string partName, int houseWorked)
        {
            this.PartName = partName;
            this.HoursWorked = houseWorked;
        }
        public string PartName { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
