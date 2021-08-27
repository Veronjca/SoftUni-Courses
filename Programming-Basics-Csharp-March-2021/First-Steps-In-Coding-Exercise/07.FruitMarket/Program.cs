using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double amounOfBananasInKilos = double.Parse(Console.ReadLine());
            double amounOfOrangesInKilos = double.Parse(Console.ReadLine());
            double amountOfBerriesInKilos = double.Parse(Console.ReadLine());
            double amountOfStrawberriesInKilos = double.Parse(Console.ReadLine());

            double berriesPrice = strawberryPrice / 2;
            double orangesPrice = berriesPrice * 0.6;
            double bananasPrice = berriesPrice * 0.2;

            double moneyNeeded =( (berriesPrice * amountOfBerriesInKilos) + (orangesPrice * amounOfOrangesInKilos) + (bananasPrice * amounOfBananasInKilos) + (strawberryPrice * amountOfStrawberriesInKilos));

            Console.WriteLine(moneyNeeded);
        }
    }
}
