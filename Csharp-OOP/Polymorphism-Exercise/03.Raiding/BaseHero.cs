using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        public abstract int Power { get;  }
        public abstract string Name { get; protected set; }

        public abstract string CastAbility();
    }
}
