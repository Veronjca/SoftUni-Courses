using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal currentBalance = decimal.Parse(Console.ReadLine());

            string game = Console.ReadLine();
            decimal moneySpent = 0; 

            while (game != "Game Time")
            {
                decimal price = 0;

                if (game == "OutFall 4")
                {
                    price = 39.99M;
                }
                else if (game == "CS: OG")
                {
                    price = 15.99M;
                }
                else if (game == "Zplinter Zell")
                {
                    price = 19.99M;
                }
                else if (game == "Honored 2")
                {
                    price = 59.99M;
                }
                else if (game == "RoverWatch")
                {
                    price = 29.99M;
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    price = 39.99M;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    game = Console.ReadLine();
                    continue;
                }

               

                if (price > currentBalance)
                {
                    Console.WriteLine("Too Expensive");
                    game = Console.ReadLine();
                    continue;
                }

                currentBalance -= price;

                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                moneySpent += price;
                Console.WriteLine($"Bought {game}");
                game = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${currentBalance:F2}");
        }
    }
}
