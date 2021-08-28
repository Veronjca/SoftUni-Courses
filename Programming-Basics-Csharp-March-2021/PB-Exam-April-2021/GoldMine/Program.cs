using System;

namespace GoldMine
{
    class Program
    {
        static void Main(string[] args)
        {
            double locations = double.Parse(Console.ReadLine());

            for (int i = 0; i < locations; i++)
            {
                double averageGoldPerDay = double.Parse(Console.ReadLine());
                double days = double.Parse(Console.ReadLine());
                double averageGoldYield = 0;
                double totalGoldYield = 0;

                for (int j = 0; j < days; j++)
                {
                    double goldYield = double.Parse(Console.ReadLine());
                    totalGoldYield += goldYield;
                    averageGoldYield = totalGoldYield / days;

                   
                }

                if (averageGoldYield >= averageGoldPerDay)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageGoldYield:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {averageGoldPerDay - averageGoldYield:f2} gold.");
                }
            }
        }
    }
}
