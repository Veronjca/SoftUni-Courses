using System;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            double bottlesBeer = double.Parse(Console.ReadLine());
            double packetsChips = double.Parse(Console.ReadLine());

            double beerPrice = bottlesBeer * 1.20;
            double chipsPrice = beerPrice * 0.45;
            double totalChipsPrice = Math.Ceiling(packetsChips * chipsPrice);

            double moneyNeeded = totalChipsPrice + beerPrice;

            if (moneyNeeded <= budget)
            {
                Console.WriteLine($"{name} bought a snack and has {budget - moneyNeeded:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {moneyNeeded - budget:f2} more leva!");
            }
        }
    }
}
