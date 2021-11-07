using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private int power = 100;
        public Paladin(string name)
        {
            this.Name = name;
        }
        public override int Power => this.power;

        public override string Name { get; protected set; }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
