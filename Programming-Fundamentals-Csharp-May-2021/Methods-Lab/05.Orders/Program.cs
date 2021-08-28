using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string productType = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());


            OrderPrice(productType, quantity);
        }

        static void OrderPrice(string productType, int quantity)
        {
            decimal totalPrice = 0;

            switch (productType)
            {
                case "coffee":
                    totalPrice = quantity * 1.50M;
                    break;
                case "water":
                    totalPrice = quantity * 1.00M;
                    break;
                case "coke":
                    totalPrice = quantity * 1.40M;
                    break;
                case "snacks":
                    totalPrice = quantity * 2.00M;
                    break;   
            }

            Console.WriteLine($"{totalPrice:f2}");
        }

       
    }
}
