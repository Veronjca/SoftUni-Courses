using System;

namespace ChristmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double adults = 0;
            double kids = 0;

            double kidsGiftsPrice = 0;
            double adultsGiftsPrice = 0;

            while (input != "Christmas")
            {
                double years = double.Parse(input);

                if (years <= 16)
                {
                    kids++;
                    kidsGiftsPrice += 5;
                }
                else
                {
                    adults++;
                    adultsGiftsPrice += 15;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Number of adults: {adults}");
            Console.WriteLine($"Number of kids: {kids}");
            Console.WriteLine($"Money for toys: {kidsGiftsPrice}");
            Console.WriteLine($"Money for sweaters: {adultsGiftsPrice}");
        }
    }
}
