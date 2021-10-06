using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    { 
        public Engine(string model, string power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }

        public string Power { get; set; }
        public string Displacement { get; set; } = "n/a";
        public string Efficiency { get; set; } = "n/a";

        public override string ToString()
        {
            return $"{this.Model}:\n    Power: {this.Power}\n    Displacement: {this.Displacement}\n    Efficiency: {this.Efficiency}";

        }
    }
}
