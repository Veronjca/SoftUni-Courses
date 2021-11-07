using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private int power = 80;

        public Rogue(string name)
        {
            this.Name = name;
        }
        public override int Power => this.power;

        public override string Name { get; protected set; }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
