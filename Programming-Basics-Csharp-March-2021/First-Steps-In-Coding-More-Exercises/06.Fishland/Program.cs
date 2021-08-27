using System;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriqPrice = double.Parse(Console.ReadLine());
            double cacaPrice = double.Parse(Console.ReadLine());
            double palamudKilos = double.Parse(Console.ReadLine());
            double safridKilos = double.Parse(Console.ReadLine());
            int midiKilos = int.Parse(Console.ReadLine());

            double palamudPrice = skumriqPrice + skumriqPrice * 0.6;
            double safridPrice = cacaPrice + cacaPrice * 0.8;
            double midiPrice = midiKilos * 7.50;

            double palamudSum = palamudKilos * palamudPrice;
            double safridSum = safridKilos * safridPrice;


            double moneyNeeded =  palamudSum + safridSum + midiPrice;
            Console.WriteLine($"{moneyNeeded:F2}");
        }
    }
}
