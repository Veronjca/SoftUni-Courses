using System;

namespace CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            double purchasedFood = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            double purchasedFoodInGrams = purchasedFood * 1000;
            double eatenFood = 0;

            while (command != "Adopted")
            {
                double food = double.Parse(command);

                eatenFood += food;

                command = Console.ReadLine();
            }

            if (eatenFood <= purchasedFoodInGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {purchasedFoodInGrams - eatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {eatenFood - purchasedFoodInGrams} grams more.");
            }

        }
    }
}
