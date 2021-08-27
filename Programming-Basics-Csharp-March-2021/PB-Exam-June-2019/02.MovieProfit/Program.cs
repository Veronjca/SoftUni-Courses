using System;

namespace MovieProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            double days = double.Parse(Console.ReadLine());
            double ticketsQuantity = double.Parse(Console.ReadLine());
            double priceTickets = double.Parse(Console.ReadLine());
            double percentForTheCinema = double.Parse(Console.ReadLine());

            double totalTickets = days * ticketsQuantity;
            double totalTicketsPrice = totalTickets * priceTickets;

            double percentage = percentForTheCinema / 100;
            double moneyForTheCinema = totalTicketsPrice * percentage;

            double profit = totalTicketsPrice - moneyForTheCinema;

            Console.WriteLine($"The profit from the movie {movieName} is {profit:F2} lv.");
        }
    }
}
