using System;

namespace CharityCapmaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int pastry = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakePrice = 45;
            double wafflesPrice = 5.80;
            double pancakesPrice = 3.20;

            double priceOfCakesBaked = cakes * cakePrice;
            double priceOfWafflesBaked = waffles * wafflesPrice;
            double priceOfPancakesBaked = pancakes * pancakesPrice;

            double moneyRaisedForOneDay = ((priceOfCakesBaked + priceOfPancakesBaked + priceOfWafflesBaked) * pastry);
            double moneyRaised = moneyRaisedForOneDay * days;
            double moneySpentForIngredients = moneyRaised / 8;

            double totalMoneyRaised = moneyRaised - moneySpentForIngredients;

            Console.WriteLine(totalMoneyRaised);
        }
    }
}
