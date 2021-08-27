using System;

namespace PriceTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            double price = 0.0;

            if (kilometers < 20)
            {
                if (dayOrNight == "day")
                {
                     price = 0.70 + (kilometers * 0.79);
                }
                else if (dayOrNight == "night")
                {
                    price = 0.70 + (kilometers * 0.90);
                }
            }
            else if ( kilometers >= 20 && kilometers < 100)
            {
               price = kilometers * 0.09;
            }
            else
            {
                price = kilometers * 0.06;
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}
