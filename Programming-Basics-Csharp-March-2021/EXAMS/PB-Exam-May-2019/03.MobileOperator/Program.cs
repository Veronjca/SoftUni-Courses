using System;

namespace MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractTerm = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileInternet = Console.ReadLine();
            double months = double.Parse(Console.ReadLine());

            double monthlyTax = 0;

            switch (contractTerm)
            {
                case "one":
                    switch (contractType)
                    {
                        case "Small":
                            monthlyTax = 9.98;
                            break;
                        case "Middle":
                            monthlyTax = 18.99;
                            break;
                        case "Large":
                            monthlyTax = 25.98;
                            break;
                        case "ExtraLarge":
                            monthlyTax = 35.99;
                            break;
                    }
                    break;
                case "two":
                    switch (contractType)
                    {
                        case "Small":
                            monthlyTax = 8.58;
                            break;
                        case "Middle":
                            monthlyTax = 17.09;
                            break;
                        case "Large":
                            monthlyTax = 23.59;
                            break;
                        case "ExtraLarge":
                            monthlyTax = 31.79;
                            break;
                    }
                    break;
            }

            switch (mobileInternet)
            {
                case "yes":
                    if (monthlyTax <= 10.00)
                    {
                        monthlyTax += 5.50;
                    }
                    else if (monthlyTax > 10 && monthlyTax <= 30)
                    {
                        monthlyTax += 4.35;
                    }
                    else if (monthlyTax > 30)
                    {
                        monthlyTax += 3.85;
                    }
                    break;
            }

            double total = months * monthlyTax;

            if (contractTerm == "two")
            {
                total -= total * (3.75 / 100);
            }

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
