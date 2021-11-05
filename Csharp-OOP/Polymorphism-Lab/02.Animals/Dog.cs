using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }
        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()}{Environment.NewLine}DJAAF";
        }
    }
}
