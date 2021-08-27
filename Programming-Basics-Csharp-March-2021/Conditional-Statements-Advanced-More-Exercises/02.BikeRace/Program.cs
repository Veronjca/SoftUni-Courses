using System;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            double juniors = double.Parse(Console.ReadLine());
            double seniors = double.Parse(Console.ReadLine());
            string traceType = Console.ReadLine();

            double totalMoneyCollected = 0;

            switch (traceType)
            {
                case "trail":
                    totalMoneyCollected = (seniors * 7) + (juniors * 5.5);
                    break;
                case "cross-country":
                    if (juniors + seniors >= 50)
                    {
                        double collectedMoney = (seniors * 9.5) + (juniors * 8);
                        double discount = collectedMoney * 0.25;
                        totalMoneyCollected = collectedMoney - discount;
                    }
                    else
                    {
                        totalMoneyCollected = (seniors * 9.5) + (juniors * 8);
                    }
                    break;
                case "downhill":
                    totalMoneyCollected = (seniors * 13.75) + (juniors * 12.25);
                    break;
                case "road":
                    totalMoneyCollected = (seniors * 21.5) + (juniors * 20);
                    break;
            }

            double moneyDonated = totalMoneyCollected - (totalMoneyCollected * 0.05);
            Console.WriteLine($"{moneyDonated:f2}");
        }
    }
}
