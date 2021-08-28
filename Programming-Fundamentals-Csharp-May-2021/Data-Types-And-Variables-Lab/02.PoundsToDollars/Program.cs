using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal britishPounds = decimal.Parse(Console.ReadLine());

            decimal USdollars = britishPounds * 1.31m;

            Console.WriteLine($"{USdollars:F3}");
        }
    }
}
