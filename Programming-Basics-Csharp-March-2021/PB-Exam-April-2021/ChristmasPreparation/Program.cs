using System;

namespace Exam18._4._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            double christmasPaper = double.Parse(Console.ReadLine());
            double cloth = double.Parse(Console.ReadLine());
            double glue = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double sum = christmasPaper * 5.80 + cloth * 7.20 + glue * 1.20;
            double totalDiscount = discount / 100;
            double totalSum = sum - (sum * totalDiscount);

            Console.WriteLine($"{totalSum:f3}");
        }
    }
}
