using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            double totalTickets = 0;
            double studentTickets = 0;
            double kidTickets = 0;
            double standardTickets = 0;

            while (movieName != "Finish")
            {
                int availableSeats = int.Parse(Console.ReadLine());
                string ticketType = Console.ReadLine();

                double hallFullnessPercentage = 0;
                int tickets = 0;

                while (ticketType != "End")
                {
                    tickets++;

                    hallFullnessPercentage = (double)tickets / availableSeats * 100;

                    if (ticketType == "student")
                    {
                        studentTickets++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTickets++;
                    }
                    else
                    {
                        standardTickets++;
                    }
                    if (tickets == availableSeats)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();


                }
                totalTickets += tickets;

                Console.WriteLine($"{movieName} - {hallFullnessPercentage:f2}% full.");
                movieName = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTickets}");

            double standardTicketsPercentage = standardTickets / totalTickets * 100;
            double kidTicketsPercentage = kidTickets / totalTickets * 100;
            double studentTicketsPercentage = studentTickets / totalTickets * 100;

            Console.WriteLine($"{studentTicketsPercentage:f2}% student tickets.");
            Console.WriteLine($"{standardTicketsPercentage:f2}% standard tickets.");
            Console.WriteLine($"{kidTicketsPercentage:f2}% kids tickets.");
        }
    }
}
