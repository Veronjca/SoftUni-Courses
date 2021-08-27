using System;

namespace SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            double students = double.Parse(Console.ReadLine());
            double nights = double.Parse(Console.ReadLine());

            double nightsPrice = 0;
            string sport = "";

            switch (season)
            {
                case "Winter":
                    if (groupType == "boys" || groupType == "girls")
                    {
                        nightsPrice = 9.60;
                    }
                    else
                    {
                        nightsPrice = 10;
                    }
                    break;
                case "Spring":
                    if (groupType == "boys" || groupType == "girls")
                    {
                        nightsPrice = 7.20;
                    }
                    else
                    {
                        nightsPrice = 9.50;
                    }
                    break;
                case "Summer":
                    if (groupType == "boys" || groupType == "girls")
                    {
                        nightsPrice = 15;
                    }
                    else
                    {
                        nightsPrice = 20;
                    }
                    break;
            }

            double moneySpent = nights * nightsPrice;
            double totalMoneySpent = 0;

            if (students >= 20 && students < 50)
            {
                totalMoneySpent = moneySpent - (moneySpent * 0.15);
            }
            else if (students >= 10 && students < 20)
            {
                totalMoneySpent = moneySpent - (moneySpent * 0.05);
            }
            else if (students >= 50)
            {
                totalMoneySpent = moneySpent / 2;
            }
            else
            {
                totalMoneySpent = moneySpent;
            }

            switch (season)
            {
                case "Winter":
                    switch (groupType)
                    {
                        case "girls":
                            sport = "Gymnastics";
                            break;
                        case "boys":
                            sport = "Judo";
                            break;
                        case "mixed":
                            sport = "Ski";
                            break;
                    }
                    break;
                case "Spring":
                    switch (groupType)
                    {
                        case "girls":
                            sport = "Athletics";
                            break;
                        case "boys":
                            sport = "Tennis";
                            break;
                        case "mixed":
                            sport = "Cycling";
                            break;
                    }
                    break;
                case "Summer":
                    switch (groupType)
                    {
                        case "girls":
                            sport = "Volleyball";
                            break;
                        case "boys":
                            sport = "Football";
                            break;
                        case "mixed":
                            sport = "Swimming";
                            break;
                    }
                    break;
            }

            double finalMoneySpent = totalMoneySpent * students;
            Console.WriteLine($"{sport} {finalMoneySpent:f2} lv.");
        }
    }
}
