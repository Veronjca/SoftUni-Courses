using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(ReadArrayFromConsole());
            Stack<int> ingredients = new Stack<int>(ReadArrayFromConsole());

            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                { "Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0}
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient;
                if (sum == 25)
                {
                    dishes["Bread"]++;
                }
                else if (sum == 50)
                {
                    dishes["Cake"]++;
                }
                else if (sum == 75 )
                {
                    dishes["Pastry"]++;
                }
                else if (sum == 100)
                {
                    dishes["Fruit Pie"]++;
                }
                else
                {
                    ingredients.Push(ingredient + 3);
                }
            }

            if (dishes["Fruit Pie"] > 0 && dishes["Pastry"] > 0 && dishes["Cake"] > 0 && dishes["Bread"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            Console.WriteLine($"Liquids left: {(liquids.Count > 0 ? string.Join(", ", liquids) : "none")}");
            Console.WriteLine($"Ingredients left: {(ingredients.Count > 0 ? string.Join(", ", ingredients) : "none")}");

            foreach (var dish in dishes.OrderBy(d => d.Key))
            {
                Console.WriteLine($"{dish.Key}: {dish.Value}");
            }
        }

        private static IEnumerable<int> ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}
