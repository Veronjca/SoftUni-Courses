using System;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string setType = Console.ReadLine();
            double orderedSets = double.Parse(Console.ReadLine());

            double price = 0;

            switch (setType)
            {
                case "small":
                    if (fruit == "Watermelon")
                    {
                        price = 2 * 56;
                    }
                    else if (fruit == "Mango")
                    {
                        price = 2 * 36.66;
                    }
                    else if (fruit == "Pineapple")
                    {

                        price = 2 * 42.10;
                    }
                    else
                    {
                        price = 2 * 20;
                    }
                    break;
                case "big":
                    if (fruit == "Watermelon")
                    {
                        price = 5 * 28.70;
                    }
                    else if (fruit == "Mango")
                    {
                        price = 5 * 19.60;
                    }
                    else if (fruit == "Pineapple")
                    {

                        price = 5 * 24.80;
                    }
                    else
                    {
                        price = 5 * 15.20;
                    }
                    break;
            }

            double totalPrice = orderedSets * price;
            double discount = 0;

            if (totalPrice >= 400 && totalPrice <= 1000)
            {
                discount = 0.15;
            }
            else if (totalPrice > 1000)
            {
                discount = 0.5;
            }

            double finalPrice = totalPrice - (totalPrice * discount);
            
            Console.WriteLine($"{finalPrice:f2} lv.");
        }
    }
}
