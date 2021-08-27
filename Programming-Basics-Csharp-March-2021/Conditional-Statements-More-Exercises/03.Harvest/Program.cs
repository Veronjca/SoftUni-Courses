using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            // кв.м е лозето – цяло число в интервала
            int X = int.Parse(Console.ReadLine());
            //грозде за един кв.м – реално число в интервала 
            double Y = double.Parse(Console.ReadLine());
            //нужни литри вино – цяло число в интервала 
            int Z = int.Parse(Console.ReadLine());
            //брой работници – цяло число в интервала 
            int workers = int.Parse(Console.ReadLine());

            double wineProduced = ((X * Y) * 0.4) / 2.5;

            if (wineProduced < Z)
            {
                double wineNeeded = Math.Floor(Z - wineProduced);
                Console.WriteLine($"It will be a tough winter! More {wineNeeded} liters wine needed.");

            }
            else
            {
                double totalWine = Math.Floor(wineProduced);
                Console.WriteLine($"Good harvest this year! Total wine: {totalWine} liters.");

                double wineLeft = Math.Ceiling(wineProduced - Z);
                double wineForOneWorker = Math.Ceiling(wineLeft / workers);
                Console.WriteLine($"{wineLeft} liters left -> {wineForOneWorker} liters per person.");
            }    

        }
    }
}
