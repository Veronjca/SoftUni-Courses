using System;

namespace FilmPremiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string packet = Console.ReadLine();
            double ticketQuantity = double.Parse(Console.ReadLine());

            double ticketPrice = 0;

            switch (movie)
            {
                case "John Wick":
                    switch (packet)
                    {
                        case "Drink":
                            ticketPrice = 12;
                            break;
                        case "Popcorn":
                            ticketPrice = 15;
                            break;
                        case "Menu":
                            ticketPrice = 19;
                            break;
                    }
                    break;
                case "Star Wars":
                    switch (packet)
                    {
                        case "Drink":
                            ticketPrice = 18;
                            break;
                        case "Popcorn":
                            ticketPrice = 25;
                            break;
                        case "Menu":
                            ticketPrice = 30;
                            break;
                    }
                    break;
                case "Jumanji":
                    switch (packet)
                    {
                        case "Drink":
                            ticketPrice = 9;
                            break;
                        case "Popcorn":
                            ticketPrice = 11;
                            break;
                        case "Menu":
                            ticketPrice = 14;
                            break;
                    }
                    break;
            }

            double total = ticketQuantity * ticketPrice;
            double discount = 0;
          

            if (movie == "Star Wars" && ticketQuantity >= 4)
            {
                discount = total * 0.3;
            }
            if (movie == "Jumanji" && ticketQuantity == 2)
            {
                discount =  total * 0.15;
            }



            double bill = total - discount;

            Console.WriteLine($"Your bill is {bill:f2} leva.");
        }
    }
}
