using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double videoCards = double.Parse(Console.ReadLine());
            double processors = double.Parse(Console.ReadLine());
            double RAM = double.Parse(Console.ReadLine());

            double videoCardsPrice = videoCards * 250;
            double processorsPrice = processors * (videoCardsPrice * 0.35);
            double RAMPrice = RAM * (videoCardsPrice * 0.1);

            double totalPrice = videoCardsPrice + processorsPrice + RAMPrice;

            if (videoCards > processors)
            {
                totalPrice -= totalPrice * 0.15;
            }

            if (totalPrice <= budget)
            {
                Console.WriteLine($"You have {budget - totalPrice:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:F2} leva more!");
            }
        }
    }
}
