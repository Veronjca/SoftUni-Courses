using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double cakePrice = rent * 0.20;
            double drinksPrice = cakePrice * 0.55;
            double animatorPrice = rent / 3;

            Console.WriteLine(rent + cakePrice + drinksPrice + animatorPrice);
        }
    }
}
