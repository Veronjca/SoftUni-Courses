using System;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int hyacinths = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactuses = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double order = (magnolias * 3.25) + (hyacinths * 4) + (roses * 3.50) + (cactuses * 8);
            double tax = order * 0.05;

            double totalOrderAmount = order - tax;

            if (totalOrderAmount >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(totalOrderAmount - giftPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(giftPrice - totalOrderAmount)} leva.");
            }
        }
    }
}
