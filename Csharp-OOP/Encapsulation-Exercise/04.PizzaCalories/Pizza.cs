using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name 
        { 
            get => this.name; 
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough 
        { 
            get => this.dough; 
            set => this.dough = value; 
        }
        public int ToppingsCount => this.toppings.Count;
        public double TotalCalories
        {
            get 
            {
                double calories = this.Dough.CaloriesPerGram;
                foreach (var topping in this.toppings)
                {
                    calories += topping.CaloriesPerGram;
                }
                return calories;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
    }
}
