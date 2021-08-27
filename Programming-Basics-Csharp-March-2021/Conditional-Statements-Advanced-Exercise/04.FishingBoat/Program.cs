using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double rent = 0;

            switch (season)
            {
                case "Spring":
                    if (fishermans <= 6)
                    {
                        rent = 3000 - (3000 * 0.1);
                    }
                    else if (fishermans > 7 && fishermans <=11 )
                    {
                        rent = 3000 - (3000 * 0.15);
                    }
                    else
                    {
                        rent = 3000 - (3000 * 0.25);
                    }
                    break;
                case "Summer":
                case "Autumn":
                    if (fishermans <= 6)
                    {
                        rent = 4200 - (4200 * 0.1);
                    }
                    else if (fishermans > 7 && fishermans <= 11)
                    {
                        rent = 4200 - (4200 * 0.15);
                    }
                    else
                    {
                        rent = 4200 - (4200 * 0.25);
                    }
                    break;
                case "Winter":
                    if (fishermans <= 6)
                    {
                        rent = 2600 - (2600 * 0.1);
                    }
                    else if (fishermans > 7 && fishermans <= 11)
                    {
                        rent = 2600 - (2600 * 0.15);
                    }
                    else
                    {
                        rent = 2600 - (2600 * 0.25);
                    }
                    break;
            }

            double finalRent = 0;

            if (fishermans % 2 == 0 && season != "Autumn")
            {
                finalRent = rent - (rent * 0.05);
            }
            else
            {
                finalRent = rent;
            }

            if (finalRent <= budget)
            {
                Console.WriteLine($"Yes! You have {(budget - finalRent):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(finalRent - budget):F2} leva.");

            }
        }
    }
}
