using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Cat : Feline
    {
        private const double GainWeight = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = livingRegion;
            this.Breed = breed;
        }

        public override string Breed { get; set; }
        public override string LivingRegion { get; set; }
        public override string Name { get; set; }
        public override double Weight { get; set; }
        public override int FoodEaten { get; set; }

        public override void EatFood(Food food)
        {           
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }
            this.Weight += food.Quantity * GainWeight;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
