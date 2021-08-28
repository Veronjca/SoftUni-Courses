using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            uint startingYield = uint.Parse(Console.ReadLine());

            byte days = 0;
            uint minedSpice = 0;

          
            while (startingYield >= 100)
            {
                days++;
                minedSpice += startingYield - 26;
                startingYield -= 10;
                
            }

            if (startingYield >= 26 && minedSpice != 0)
            {
                minedSpice -= 26;
            }

           
            Console.WriteLine(days);
            Console.WriteLine(minedSpice);
        }
    }
}
