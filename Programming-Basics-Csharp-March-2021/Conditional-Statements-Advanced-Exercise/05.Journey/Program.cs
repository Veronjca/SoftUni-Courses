using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string place = "";
            double moneySpent = 0;

            if (budget <= 100 && season == "summer")
            {
                moneySpent = budget * 0.3;
                destination = "Bulgaria";
                place = "Camp";
            }
            else if (budget <= 100 && season == "winter")
            {
                moneySpent = budget * 0.7;
                destination = "Bulgaria";
                place = "Hotel";
            }

            else if ( budget > 100 && budget <=1000 && season == "summer")
            {
                moneySpent = budget * 0.4;
                destination = "Balkans";
                place = "Camp";
            }
            else if (budget > 100 && budget <= 1000 && season == "winter")
            {
                moneySpent = budget * 0.8;
                destination = "Balkans";
                place = "Hotel";
            }
            else 
            {
                moneySpent = budget * 0.9;
                destination = "Europe";
                place = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {moneySpent:F2}");
        }
    }
}
