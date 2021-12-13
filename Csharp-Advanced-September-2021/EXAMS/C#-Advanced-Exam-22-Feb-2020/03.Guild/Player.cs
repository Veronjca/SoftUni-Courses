using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string @class)
        {
            this.Name = name;
            this.Class = @class;
        }

        public string Name { get; private set; }
        public string Class { get; private set; }
        public string Rank { get; set; } = "Trial";
        public string Description { get; set; } = "n/a";

        public override string ToString()
        {
            return $"Player {this.Name}: {this.Class}{Environment.NewLine}Rank: {this.Rank}{Environment.NewLine}Description: {this.Description}";
        }
    }
}
