using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class DruidFactory : HeroFactory
    {
        private string name;
        public DruidFactory(string name)
        {
            this.name = name;
        }
        public override BaseHero GetHero()
        {
            return new Druid(this.name);
        }
    }
}
