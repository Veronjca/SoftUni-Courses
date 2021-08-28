using System;

namespace Exam25._4._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            double videoCardPrice = double.Parse(Console.ReadLine());
            double prehodnikPrice = double.Parse(Console.ReadLine());
            double electricity = double.Parse(Console.ReadLine());
            double profit = double.Parse(Console.ReadLine());

            double totalPriceVideoCard = 13 * videoCardPrice;
            double totalPricePrehodnik = 13 * prehodnikPrice;

            double totalCosts = totalPricePrehodnik + totalPriceVideoCard + 1000;

            double electricityNeeded = profit - electricity;
            double totalProfit = 13 * electricityNeeded;

            double days = totalCosts / totalProfit;

            Console.WriteLine(totalCosts);
            Console.WriteLine($"{Math.Ceiling(days)}");

        }
    }
}
