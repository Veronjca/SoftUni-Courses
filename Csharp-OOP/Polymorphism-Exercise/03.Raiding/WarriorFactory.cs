using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class WarriorFactory : HeroFactory
    {
        private string name;

        public WarriorFactory(string name)
        {
            this.name = name;
        }
        public override BaseHero GetHero()
        {
            return new Warrior(this.name);
        }
    }
}
