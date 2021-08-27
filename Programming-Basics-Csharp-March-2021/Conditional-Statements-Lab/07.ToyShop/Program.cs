using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzelsCount = int.Parse(Console.ReadLine());
            int talkingDollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double orderedToys = puzzelsCount + talkingDollsCount + teddyBearsCount + minionsCount + trucksCount;
            double priceSum = (puzzelsCount * 2.60) + (talkingDollsCount * 3) + (teddyBearsCount * 4.10) + (minionsCount * 8.20) + (trucksCount * 2);
            double discount = 0 ;
            
           
            if (orderedToys >= 50)
            {
               discount = priceSum * 0.25;
            }

            double moneyEarned = priceSum - discount;
            double rent = moneyEarned * 0.10;
            double totalMoneyEarned = moneyEarned - rent;

            if (tripPrice <= totalMoneyEarned)
            {
                double moneyLeft = totalMoneyEarned - tripPrice;
                Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
            }

            else
            {
                double moneyNeeded = tripPrice - totalMoneyEarned;
                Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
            }
        }
    }
}
