using System;

namespace ConditionalStatementsMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string ticketType = Console.ReadLine();
            double people = double.Parse(Console.ReadLine());

            double ticketVIP = 499.99 * people;
            double normalTicket = 249.99 * people;

            double moneyForTransport = 0;

            if (people >= 1 && people <= 4)
            {
                moneyForTransport = budget * 0.75;
            }
            else if (people >= 5 && people <= 9)
            {
                moneyForTransport = budget * 0.6;
            }
            else if (people >= 10 && people <= 24)
            {
                moneyForTransport = budget * 0.5;
            }
            else if (people >= 25 && people <= 49)
            {
                moneyForTransport = budget * 0.4;
            }
            else
            {
                moneyForTransport = budget * 0.25;
            }

            double totalBudget = budget - moneyForTransport;

            switch (ticketType)
            {
                case "VIP":
                    if (totalBudget > ticketVIP)
                    {
                        Console.WriteLine($"Yes! You have {(totalBudget - ticketVIP):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {(ticketVIP - totalBudget):f2} leva.");
                    }
                    break;
                case "Normal":
                    if (totalBudget > normalTicket)
                    {
                        Console.WriteLine($"Yes! You have {(totalBudget - normalTicket):f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {(normalTicket - totalBudget):f2} leva.");
                    }
                    break;
            }
        }
    }
}
