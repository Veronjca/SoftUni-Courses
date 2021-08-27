using System;

namespace OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string hallType = Console.ReadLine();
            double tickets =double.Parse(Console.ReadLine());

            double price = 0;

            switch (hallType)
            {
                case "normal":
                    switch (movie)
                    {
                        case "A Star Is Born":
                            price = 7.50;
                            break;
                        case "Bohemian Rhapsody":
                            price = 7.35;
                            break;
                        case "Green Book":
                            price = 8.15;
                            break;
                        case "The Favourite":
                            price = 8.75;
                            break;
                    }
                    break;
                case "luxury":
                    switch (movie)
                    {
                        case "A Star Is Born":
                            price = 10.50;
                            break;
                        case "Bohemian Rhapsody":
                            price = 9.45;
                            break;
                        case "Green Book":
                            price = 10.25;
                            break;
                        case "The Favourite":
                            price = 11.55;
                            break;
                    }
                    break;
                case "ultra luxury":
                    switch (movie)
                    {
                        case "A Star Is Born":
                            price = 13.50;
                            break;
                        case "Bohemian Rhapsody":
                            price = 12.75;
                            break;
                        case "Green Book":
                            price = 13.25;
                            break;
                        case "The Favourite":
                            price = 13.95;
                            break;
                    }
                    break;

            }

            double totalPrice = tickets * price;

            Console.WriteLine($"{movie} -> {totalPrice:F2} lv.");
        }
    }
}
