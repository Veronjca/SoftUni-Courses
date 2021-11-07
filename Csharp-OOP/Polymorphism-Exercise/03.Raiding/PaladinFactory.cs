using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class PaladinFactory : HeroFactory
    {
        private string name;
        public PaladinFactory(string name)
        {
            this.name = name;
        }
        public override BaseHero GetHero()
        {
            return new Paladin(this.name);
        }
    }
}
