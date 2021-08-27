using System;

namespace GodzilaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double extras = double.Parse(Console.ReadLine());
            double costumePrice = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;
            double totalCostumePrice = extras * costumePrice;

            if (extras >150)
            {
                totalCostumePrice -= totalCostumePrice * 0.1;
            }

            double moneyNeeded = decor + totalCostumePrice;

            if (moneyNeeded <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - moneyNeeded:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded - budget:F2} leva more.");
            }
        }
    }
}
