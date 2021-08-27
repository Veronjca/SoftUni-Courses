using System;

namespace FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double nights = double.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            double additional = double.Parse(Console.ReadLine());

            if (nights > 7)
            {
                price = price - (price * 0.05);
            }

            additional /= 100;

            double additionalExpenses = budget * additional;

            double moneyNeeded = nights * price + additionalExpenses;

            if (moneyNeeded <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - moneyNeeded:F2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{moneyNeeded - budget:F2} leva needed.");
            }
        }
    }
}
