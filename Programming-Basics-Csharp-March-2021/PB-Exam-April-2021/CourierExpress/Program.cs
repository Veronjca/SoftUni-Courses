using System;

namespace CourierExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            double distance = double.Parse(Console.ReadLine());

            double price = 0;
            double priceExpress = 0;

            if (weight < 1)
            {
                price = 0.03;
                priceExpress = 0.03 * 0.8;
                
            }
            else if (weight >= 1 && weight < 10)
            {
                price = 0.05;
                priceExpress = 0.05 * 0.4;
            }
            else if (weight >= 10 && weight < 40)
            {
                price = 0.10;
                priceExpress = 0.10 * 0.05;
            }
            else if (weight >= 40 && weight < 90)
            {
                price = 0.15;
                priceExpress = 0.15 * 0.02;
            }
            else if (weight >= 90 && weight < 150)
            {
                price = 0.20;
                priceExpress = 0.20 * 0.01;
            }

            double standardPrice = 0;
            double expressPrice = 0;
            double increaseKilos = 0;
            double increaseKilometers = 0;
            

            if (type == "standard")
            {
                standardPrice = distance * price;
            }
            else if(type == "express")
            {
                increaseKilos = priceExpress * weight;
                standardPrice = distance * price;
                increaseKilometers = increaseKilos * distance;
                expressPrice = standardPrice + increaseKilometers;
            }

            if (type == "standard")
            {
                Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {standardPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {expressPrice:f2} lv.");
            }

            
        }
    }
}

