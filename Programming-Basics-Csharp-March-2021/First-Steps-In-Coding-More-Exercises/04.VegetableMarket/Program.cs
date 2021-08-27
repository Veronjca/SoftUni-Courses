using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfVegetablesForKilos = double.Parse(Console.ReadLine());
            double priceOfFruitsForKilos = double.Parse(Console.ReadLine());
            double totalKilosVegetables = double.Parse(Console.ReadLine());
            double totalKilosFruits = double.Parse(Console.ReadLine());

            double totalIncomeInLeva = (priceOfFruitsForKilos * totalKilosFruits) + (priceOfVegetablesForKilos * totalKilosVegetables);
            double totalIncomeInEuro = totalIncomeInLeva / 1.94;

            Console.WriteLine($"{totalIncomeInEuro:F2}");
        }
    }
}
