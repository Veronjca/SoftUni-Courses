using System;

namespace TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometersMonthly = double.Parse(Console.ReadLine());

            double earnedMoney = 0;

            switch (season)
            {
                case "Spring":
                case "Autumn":
                    if (kilometersMonthly <= 5000)
                    {
                        earnedMoney = (kilometersMonthly * 0.75) * 4;
                    }
                    else if (kilometersMonthly > 5000 && kilometersMonthly <= 10000)
                    {
                        earnedMoney = (kilometersMonthly * 0.95) * 4;
                    }
                    else if (kilometersMonthly > 10000 && kilometersMonthly <= 20000)
                    {
                        earnedMoney = (kilometersMonthly * 1.45) * 4;
                    }
                    break;
                case "Summer":
                    if (kilometersMonthly <= 5000)
                    {
                        earnedMoney = (kilometersMonthly * 0.90) * 4;
                    }
                    else if (kilometersMonthly > 5000 && kilometersMonthly <= 10000)
                    {
                        earnedMoney = (kilometersMonthly * 1.10) * 4;
                    }
                    else if (kilometersMonthly > 10000 && kilometersMonthly <= 20000)
                    {
                        earnedMoney = (kilometersMonthly * 1.45) * 4;
                    }
                    break;
                case "Winter":
                    if (kilometersMonthly <= 5000)
                    {
                        earnedMoney = (kilometersMonthly * 1.05) * 4;
                    }
                    else if (kilometersMonthly > 5000 && kilometersMonthly <= 10000)
                    {
                        earnedMoney = (kilometersMonthly * 1.25) * 4;
                    }
                    else if (kilometersMonthly > 10000 && kilometersMonthly <= 20000)
                    {
                        earnedMoney = (kilometersMonthly * 1.45) * 4;
                    }
                    break;
            }

            double totalMoneyEarned = earnedMoney - (earnedMoney * 0.1);
            Console.WriteLine($"{totalMoneyEarned:f2}");
        }
    }
}
