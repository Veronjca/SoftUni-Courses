using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            //храна на ден за кучето в килограми 
            double dogFood = double.Parse(Console.ReadLine());
            //храна на ден за котката в килограми
            double catFood = double.Parse(Console.ReadLine());
            //храна на ден за костенурката в грамове 
            double turtleFood = double.Parse(Console.ReadLine());

            double turtleFoodInKg = turtleFood / 1000;

            double neededDogFood = dogFood * days;
            double neededCatFood = catFood * days;
            double neededTurtleFood = turtleFoodInKg * days;

            double totalFoodNeeded = neededCatFood + neededDogFood + neededTurtleFood;

            if (food >= totalFoodNeeded )
            {
                Console.WriteLine($"{Math.Floor(food - totalFoodNeeded)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFoodNeeded - food)} more kilos of food are needed.");
            }

        }
    }
}
