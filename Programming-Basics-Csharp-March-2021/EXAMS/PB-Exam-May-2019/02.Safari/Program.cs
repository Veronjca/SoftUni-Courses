using System;

namespace Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double gasNeeded = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double gasTotal = gasNeeded * 2.10;
            const double guidePrice = 100;

            double moneyNeeded = gasTotal + guidePrice;

            if (day == "Saturday")
            {
                moneyNeeded -= moneyNeeded * 0.1;
            }
            else if (day == "Sunday")
            {
                moneyNeeded -= moneyNeeded * 0.2;
            }

            if (budget >= moneyNeeded)
            {
                Console.WriteLine($"Safari time! Money left: {budget - moneyNeeded:f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {moneyNeeded - budget:f2} lv.");
            }
        }
    }
}
