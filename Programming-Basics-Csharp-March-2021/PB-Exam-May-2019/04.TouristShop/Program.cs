using System;

namespace TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string productName = Console.ReadLine();


            double counter = 0;
            double totalPrice = 0;


            while (productName != "Stop")
            {
                double price = double.Parse(Console.ReadLine());
                counter++;


                if (counter % 3 == 0)
                {
                    price /= 2;
                }

                if (price > budget)
                {

                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {price - budget:F2} leva!");
                    return;
                }
                budget -= price;
                totalPrice += price;


                productName = Console.ReadLine();

            }


            Console.WriteLine($"You bought {counter} products for {totalPrice:f2} leva.");
        }
    }
}

