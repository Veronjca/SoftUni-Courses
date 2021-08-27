using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
           double pens = double.Parse(Console.ReadLine());
           double markers = double.Parse(Console.ReadLine());
           double abstergent = double.Parse(Console.ReadLine());
           double discount = double.Parse(Console.ReadLine());

            double pensPrice = pens * 5.80;
            double markersPrice = markers * 7.20;
            double abstergentPrice = abstergent * 1.20;

            double totalDiscount = discount / 100;
            double totalPrice = (pensPrice + markersPrice + abstergentPrice);

            double moneyNeeded = totalPrice - (totalPrice * totalDiscount);

            Console.WriteLine($"{moneyNeeded:f3}");
        }
    }
}
