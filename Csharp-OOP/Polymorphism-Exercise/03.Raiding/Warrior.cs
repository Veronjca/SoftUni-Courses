using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        private int power = 100;

        public Warrior(string name)
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
