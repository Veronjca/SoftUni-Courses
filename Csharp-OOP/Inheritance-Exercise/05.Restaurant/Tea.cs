using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double grams)
            : base(name, price, grams)
        {

        }
    }
}
