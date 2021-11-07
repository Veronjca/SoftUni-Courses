using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class RogueFactory : HeroFactory
    {
        private string name;
        public RogueFactory(string name)
        {
            this.name = name;
        }
        public override BaseHero GetHero()
        {
            return new Rogue(this.name);
        }
    }
}
