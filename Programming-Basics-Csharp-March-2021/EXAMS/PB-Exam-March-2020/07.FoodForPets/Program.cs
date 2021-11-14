using System;

namespace FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            int amountOfFood = int.Parse(Console.ReadLine());


            double eatenFoodDog = 0;
            double eatenFoodCat = 0;
            double biscuits = 0;
            double totalEatenFood = 0;

            for (int i = 1; i <= days; i++)
            {
                
                double dogFood = double.Parse(Console.ReadLine());
                double catFood = double.Parse(Console.ReadLine());

                eatenFoodDog += dogFood;
                eatenFoodCat += catFood;

                
                totalEatenFood += dogFood + catFood;
                if (i % 3 == 0)
                {
                   double currentBiscuits = (dogFood + catFood) * 0.1;
                    biscuits += currentBiscuits;
                }
            }

            double percentEatenFood = (totalEatenFood / amountOfFood) * 100;
            double percentEatenFoodDog = (eatenFoodDog / totalEatenFood) * 100;
            double percentEatenFoodCat = (eatenFoodCat / totalEatenFood) * 100;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{percentEatenFood:f2}% of the food has been eaten.");
            Console.WriteLine($"{percentEatenFoodDog:f2}% eaten from the dog.");
            Console.WriteLine($"{percentEatenFoodCat:f2}% eaten from the cat.");
        }
    }

}

