using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine();
           
            double sum = 0;

            while (coins != "Start")
            {
                double currentCoin = double.Parse(coins);

                if (currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 || currentCoin == 1 || currentCoin == 2)
                {
                    sum += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }

                coins = Console.ReadLine();
            }

            string product = Console.ReadLine();

            double price = 0;
           
            while (product != "End")
            {
                bool ifPurchased = false;
                bool ifDiff = false;

                if (product == "Nuts")
                {                    
                    price = 2.0;
                }
                else if (product == "Water")
                {                   
                    price = 0.7;
                }
                else if (product == "Crisps")
                {
                    price = 1.5;
                }
                else if (product == "Soda")
                {                    
                    price = 0.8;
                }
                else if (product == "Coke")
                {                    
                    price = 1.0;
                }
                else
                {
                    ifDiff = true;
                    Console.WriteLine("Invalid product");
                }               

                if (sum >= price)
                {
                    ifPurchased = true;
                }

                if (ifPurchased)
                {
                    
                    sum -= price;
                }
                

                if (ifPurchased && ifDiff == false)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    if (ifDiff == false)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
