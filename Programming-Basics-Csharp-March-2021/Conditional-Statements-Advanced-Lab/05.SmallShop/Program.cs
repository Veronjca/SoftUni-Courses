using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        price = quantity * 0.50;
                        break;
                    case "water":
                        price = quantity * 0.80;
                        break;
                    case "beer":
                        price = quantity * 1.20;
                        break;
                    case "sweets":
                        price = quantity * 1.45;
                        break;
                    case "peanuts":
                        price = quantity * 1.60;
                        break;
                }
            }

            if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        price = quantity * 0.40;
                        break;
                    case "water":
                        price = quantity * 0.70;
                        break;
                    case "beer":
                        price = quantity * 1.15;
                        break;
                    case "sweets":
                        price = quantity * 1.30;
                        break;
                    case "peanuts":
                        price = quantity * 1.50;
                        break;
                }
            }

            if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        price = quantity * 0.45;
                        break;
                    case "water":
                        price = quantity * 0.70;
                        break;
                    case "beer":
                        price = quantity * 1.10;
                        break;
                    case "sweets":
                        price = quantity * 1.35;
                        break;
                    case "peanuts":
                        price = quantity * 1.55;
                        break;
                }
            }
            Console.WriteLine(price);
        }
    }
}
