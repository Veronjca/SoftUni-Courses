using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private int power = 80;
        public Druid(string name)
        {
            this.Name = name;
        }
        public override int Power { get => this.power; }
        public override string Name { get; protected set; }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
