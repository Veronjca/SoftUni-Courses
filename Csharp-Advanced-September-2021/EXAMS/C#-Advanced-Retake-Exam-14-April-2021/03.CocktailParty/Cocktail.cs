using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Ingredients = new List<Ingredient>();
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        public List<Ingredient> Ingredients { get; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => this.Ingredients.Sum(i => i.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (this.Ingredients.Count < this.Capacity && !this.Ingredients.Any(i => i.Name == ingredient.Name) && this.Ingredients.Sum(i => i.Alcohol) < this.MaxAlcoholLevel) 
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient current = this.Ingredients.FirstOrDefault(i => i.Name == name);
            if (current == null)
            {
                return false;
            }
            this.Ingredients.Remove(current);
            return true;
        }

        public Ingredient FindIngredient(string name)
            => this.Ingredients.FirstOrDefault(i => i.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
            => this.Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

        public string Report()
        {
            return $"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}{Environment.NewLine}{string.Join(Environment.NewLine, this.Ingredients)}";
        }
    }
}
