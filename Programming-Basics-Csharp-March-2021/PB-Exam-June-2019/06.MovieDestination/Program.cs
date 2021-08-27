using System;

namespace MovieDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            double days = double.Parse(Console.ReadLine());

            double price = 0;

            switch (destination)
            {
                case "Dubai":
                    switch (season)
                    {
                        case "Winter":
                            price = 45_000;
                            break;
                        case "Summer":
                            price = 40_000;
                            break;
                    }
                    break;
                case "Sofia":
                    switch (season)
                    {
                        case "Winter":
                            price = 17_000;
                            break;
                        case "Summer":
                            price = 12_500;
                            break;
                    }
                    break;
                case "London":
                    switch (season)
                    {
                        case "Winter":
                            price = 24_000;
                            break;
                        case "Summer":
                            price = 20_250;
                            break;
                    }
                    break;
            }

            double total = days * price;

            if (destination == "Dubai")
            {
                total -= total * 0.3;
            }

            if (destination == "Sofia")
            {
                total *= 1.25;
            }

            if (budget >= total)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget - total:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {total - budget:F2} leva more!");
            }
        }
    }
}
