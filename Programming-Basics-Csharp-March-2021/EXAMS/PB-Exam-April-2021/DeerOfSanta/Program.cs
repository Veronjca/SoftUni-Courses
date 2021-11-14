using System;

namespace DeerOfSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double foodPerDayForFirstDeer = double.Parse(Console.ReadLine());
            double foodPerDayForSecondDeer = double.Parse(Console.ReadLine());
            double foodPerDayForThirdDeer = double.Parse(Console.ReadLine());

            double foodNeeded = (foodPerDayForFirstDeer + foodPerDayForSecondDeer + foodPerDayForThirdDeer) * days;

            if (food >= foodNeeded)
            {
                Console.WriteLine($"{Math.Floor(food - foodNeeded)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodNeeded - food)} more kilos of food are needed.");
            }
        }
    }
}
