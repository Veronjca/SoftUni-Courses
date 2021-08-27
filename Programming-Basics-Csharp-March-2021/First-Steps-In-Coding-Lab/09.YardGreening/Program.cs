using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMeters = double.Parse(Console.ReadLine());

            double moneyNeeded = squareMeters * 7.61;
            double discount = moneyNeeded * 0.18;
            double finalPrice = moneyNeeded - discount;

            Console.WriteLine(($"The final price is: {finalPrice} lv."));
            Console.WriteLine(($"The discount is: { discount} lv."));

        }
    }
}
