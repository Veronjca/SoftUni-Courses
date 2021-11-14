using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray().ToList().Where(x => x != 0));
            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int dippingSauce = 0, greenSalad = 0, chocolateCake = 0, lobster = 0;

            while (ingredients.Count > 0 && freshnessLevel.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();
                int currentFreshnessLevel = freshnessLevel.Pop();
                int freshnessLevelNeeded = currentFreshnessLevel * currentIngredient;

                switch (freshnessLevelNeeded)
                {
                    case 150:
                        dippingSauce++;
                        break;
                    case 250:
                        greenSalad++;
                        break;
                    case 300:
                        chocolateCake++;
                        break;
                    case 400:
                        lobster++;
                        break;
                    default:
                        currentIngredient += 5;
                        ingredients.Enqueue(currentIngredient);
                        break;
                }
            }

            if (dippingSauce != 0 && greenSalad != 0 && chocolateCake != 0 && lobster != 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Any())
            {
                Console.WriteLine(ingredients.Sum());
            }

            if (chocolateCake != 0)
            {
                Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
            }
            if (dippingSauce != 0)
            {
                Console.WriteLine($"# Dipping sauce --> {dippingSauce}");
            }
            if (greenSalad != 0)
            {
                Console.WriteLine($"# Green salad --> {greenSalad}");
            }
            if (lobster != 0)
            {
                Console.WriteLine($"# Lobster --> {lobster}");
            }
        }
    }
}
