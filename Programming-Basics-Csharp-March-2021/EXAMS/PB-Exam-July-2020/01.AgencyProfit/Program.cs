using System;

namespace PBExams
{
    class Program
    {
        static void Main(string[] args)
        {
            string airlineName = Console.ReadLine();
            double adultTicketsQuantity = double.Parse(Console.ReadLine());
            double kidTicketsQuantity = double.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double serviceTax = double.Parse(Console.ReadLine());



            double kidTicketPrice = adultTicketPrice - (adultTicketPrice * 0.7);
            double kidTicketsTotalPrice = kidTicketPrice * kidTicketsQuantity + serviceTax * kidTicketsQuantity;
            double adultTicketsTotalPrice = adultTicketPrice * adultTicketsQuantity + serviceTax * adultTicketsQuantity;

            double profit = adultTicketsTotalPrice + kidTicketsTotalPrice;
            double totalProfit = profit * 0.2;



            Console.WriteLine($"The profit of your agency from {airlineName} tickets is {totalProfit:f2} lv.");
        }
    }
}
