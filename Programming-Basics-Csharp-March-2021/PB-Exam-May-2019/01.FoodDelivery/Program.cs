using System;

namespace PBExamMay2019
{
    class Program
    {
        static void Main(string[] args)
        {
            double chickenMenus = double.Parse(Console.ReadLine());
            double fishMenus = double.Parse(Console.ReadLine());
            double veggieMenus = double.Parse(Console.ReadLine());

            const double delivery = 2.50;

            double total = chickenMenus * 10.35 + fishMenus * 12.40 + veggieMenus * 8.15;

            double desert = total * 0.2;

            double final = total + desert + delivery;

            Console.WriteLine($"Total: {final:F2}");
        }
    }
}
