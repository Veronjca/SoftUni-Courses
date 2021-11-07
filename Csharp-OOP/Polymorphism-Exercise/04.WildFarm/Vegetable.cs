using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Vegetable : Food
    {
        public Vegetable(int quantity) 
            : base(quantity)
        {
            this.Quantity = quantity;
        }

        public override int Quantity { get; set; }
    }
}
