using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double extras = double.Parse(Console.ReadLine());
            double clothingPriceForOneExtra = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.1;

            if ( extras > 150)
            {
                clothingPriceForOneExtra = clothingPriceForOneExtra * 0.9;
            }

            double sumOfMoneyNeeded = (extras * clothingPriceForOneExtra) + decorPrice;

            if (sumOfMoneyNeeded > budget)
            {
                double moneyNeeded = sumOfMoneyNeeded - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded:F2} leva more.");
            }
            else
            {
                double moneyLeft = budget - sumOfMoneyNeeded;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
            }
        }
    }
}
