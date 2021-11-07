using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Seeds : Food
    {
        public Seeds(int quantity)
            : base(quantity)
        {
            this.Quantity = quantity;
        }

        public override int Quantity { get; set; }
    }
}
