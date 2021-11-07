using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Meat : Food
    {
        public Meat(int quantity) 
            : base(quantity)
        {
            this.Quantity = quantity;
        }

        public override int Quantity
        {
            get; set;
        }
     }
}
