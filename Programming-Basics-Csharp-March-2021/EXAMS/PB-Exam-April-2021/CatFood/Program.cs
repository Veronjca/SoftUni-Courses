using System;

namespace CatFood
{
    class Program
    {
        static void Main(string[] args)
        {
           double catsQuantity = double.Parse(Console.ReadLine());

            int group1 = 0;
            int group2 = 0;
            int group3 = 0;

            double foodAmount = 0;

            for (int i = 0; i < catsQuantity; i++)
            {
                double food = double.Parse(Console.ReadLine());

                if (food >= 100 && food < 200)
                {
                    group1++;
                }
                else if (food >= 200 && food < 300)
                {
                    group2++;
                }
                else if (food >= 300 && food < 400)
                {
                    group3++;
                }

                foodAmount += food;
            }

            double foodInKilos = foodAmount / 1000;
            double price = foodInKilos * 12.45;

            Console.WriteLine($"Group 1: {group1} cats.");
            Console.WriteLine($"Group 2: {group2} cats.");
            Console.WriteLine($"Group 3: {group3} cats.");
            Console.WriteLine($"Price for food per day: {price:f2} lv.");
        }
    }
}
