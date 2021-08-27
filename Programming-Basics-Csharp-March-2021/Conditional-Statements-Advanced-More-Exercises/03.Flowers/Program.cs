using System;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            double chrysanthemumsQuantity = double.Parse(Console.ReadLine());
            double rosesQuantity = double.Parse(Console.ReadLine());
            double tulipsQuantity = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine();

            double arrangePrice = 2;
            double rosesPrice = 0;
            double tulipsPrice = 0;
            double chrysanthemumsPrice = 0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemumsPrice = 2;
                    rosesPrice = 4.10;
                    tulipsPrice = 2.50;
                    break;
                case "Autumn":
                case "Winter":
                    chrysanthemumsPrice = 3.75;
                    rosesPrice = 4.50;
                    tulipsPrice = 4.15;
                    break;
            }

            double bouquetPrice = tulipsQuantity * tulipsPrice + rosesQuantity * rosesPrice + chrysanthemumsQuantity * chrysanthemumsPrice;

            if (holiday == "Y")
            {
                bouquetPrice = bouquetPrice + (bouquetPrice * 0.15);
            }

            if (tulipsQuantity > 7 && season == "Spring")
            {
                bouquetPrice = bouquetPrice - (bouquetPrice * 0.05);
            }
            if (rosesQuantity >= 10 && season == "Winter")
            {
                bouquetPrice = bouquetPrice - (bouquetPrice * 0.1);
            }
            if ((chrysanthemumsQuantity + rosesQuantity + tulipsQuantity) > 20)
            {
                bouquetPrice = bouquetPrice - (bouquetPrice * 0.2);
            }

            double totalBouquetPrice = bouquetPrice + arrangePrice;

            Console.WriteLine($"{totalBouquetPrice:f2}");
        }
    }
}
