using System;

namespace Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double profitNeeded = double.Parse(Console.ReadLine());

            string coctail = Console.ReadLine();


            double price = 0;
            double totalPrice = 0;

            while (coctail != "Party!")
            {
                double amount = double.Parse(Console.ReadLine());

                double coctailPrice = coctail.Length;

                price = amount * coctailPrice;

                if (price % 2 != 0)
                {
                    price -= price * 0.25;
                }

                totalPrice += price;

                if (totalPrice >= profitNeeded)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {totalPrice:f2} leva.");
                    return;
                }
                coctail = Console.ReadLine();
               
            }

            Console.WriteLine($"We need {profitNeeded - totalPrice:F2} leva more.");
            Console.WriteLine($"Club income - {totalPrice:f2} leva.");
        }
    }
}
