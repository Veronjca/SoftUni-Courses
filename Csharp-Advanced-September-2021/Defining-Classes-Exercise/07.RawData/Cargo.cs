using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        public int Weight { get; set; }

        public string Type { get; set; }
    }
}
