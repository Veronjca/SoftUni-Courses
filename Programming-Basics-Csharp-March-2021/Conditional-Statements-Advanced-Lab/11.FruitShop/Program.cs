using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        price = quantity * 2.50;
                    }
                    else if (fruit == "apple")
                    {
                        price = quantity * 1.20;
                    }
                    else if (fruit == "orange")
                    {
                        price = quantity * 0.85;
                    }
                    else if (fruit == "grapefruit")
                    {
                        price = quantity * 1.45;
                    }
                    else if (fruit == "kiwi")
                    {
                        price = quantity * 2.70;
                    }
                    else if (fruit == "pineapple")
                    {
                        price = quantity * 5.50;
                    }
                    else if (fruit == "grapes")
                    {
                        price = quantity * 3.85;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        Environment.Exit(0);
                    }
                    break;

                case "Saturday":
                case "Sunday":
                    if (fruit == "banana")
                    {
                        price = quantity * 2.70;
                    }
                    else if (fruit == "apple")
                    {
                        price = quantity * 1.25;
                    }
                    else if (fruit == "orange")
                    {
                        price = quantity * 0.90;
                    }
                    else if (fruit == "grapefruit")
                    {
                        price = quantity * 1.60;
                    }
                    else if (fruit == "kiwi")
                    {
                        price = quantity * 3.00;
                    }
                    else if (fruit == "pineapple")
                    {
                        price = quantity * 5.60;
                    }
                    else if (fruit == "grapes")
                    {
                        price = quantity * 4.20;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        Environment.Exit(0);
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}
