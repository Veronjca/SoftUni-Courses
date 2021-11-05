using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public string Name 
        { 
            get => this.name; 
            set => this.name = value;
        }
        public string FavouriteFood
        { 
            get => this.favouriteFood; 
            set => this.favouriteFood = value; 
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
        }
    }
}
