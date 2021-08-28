using System;

namespace PuppyCare
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodBought = int.Parse(Console.ReadLine());

            int foodBoughtGr = foodBought * 1000;


            double eatenFood = 0;
            string input = Console.ReadLine();

            while (input != "Adopted")
            {
                int food = int.Parse(input);

                eatenFood += food;

                input = Console.ReadLine();

               
            }

            if (eatenFood > foodBoughtGr)
            {
                Console.WriteLine($"Food is not enough. You need {eatenFood - foodBoughtGr} grams more.");
                
            }
            else
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodBoughtGr - eatenFood} grams.");
            }
            
        }
    }
}
