using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
         

            double student = 0;
            double standard = 0;
            double kid = 0;
            double totalTickets = 0;
            

            while (movieName != "Finish")
            {
                double availableSeats = double.Parse(Console.ReadLine());
                string ticketType = Console.ReadLine();
                
                double movieTickets = 0;

                while (ticketType != "End")
                {
                    if (ticketType == "student")
                    {
                        student++;
                    }
                    else if (ticketType == "standard")
                    {
                        standard++;
                    }
                    else if (ticketType == "kid")
                    {
                        kid++;
                    }

                    totalTickets++;
                    movieTickets++;

                    if (movieTickets >= availableSeats)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();
                }
                double fullness = (movieTickets / availableSeats) * 100;

                Console.WriteLine($"{movieName} - {fullness:f2}% full.");

                movieName = Console.ReadLine();
            }

            double studentTicketsPercantage = (student / totalTickets) * 100;
            double standardTicketsPercantage = (standard / totalTickets) * 100;
            double kidTicketsPercantage = (kid / totalTickets) * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTicketsPercantage:f2}% student tickets.");
            Console.WriteLine($"{standardTicketsPercantage:f2}% standard tickets.");
            Console.WriteLine($"{kidTicketsPercantage:f2}% kids tickets.");
        }
    }
}
