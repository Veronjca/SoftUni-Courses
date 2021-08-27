using System;

namespace TradeComissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sellings = double.Parse(Console.ReadLine());

            double comission = 0;

            switch (city)
            {
                case "Sofia":
                    if (sellings >= 0 && sellings <= 500)
                    {
                        comission = 0.05;
                    }
                    else if (sellings > 500 && sellings <= 1000)
                    {
                        comission = 0.07;
                    }
                    else if (sellings > 1000 && sellings <= 10000)
                    {
                        comission = 0.08;
                    }
                    else if (sellings > 10000)
                    {
                        comission = 0.12;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        Environment.Exit(0);
                    }
                    break;

                case "Varna":
                    if (sellings >= 0 && sellings <= 500)
                    {
                        comission = 0.045;
                    }
                    else if (sellings > 500 && sellings <= 1000)
                    {
                        comission = 0.075;
                    }
                    else if (sellings > 1000 && sellings <= 10000)
                    {
                        comission = 0.10;
                    }
                    else if (sellings > 10000)
                    {
                        comission = 0.13;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        Environment.Exit(0);
                    }
                    break;

                case "Plovdiv":
                    if (sellings >= 0 && sellings <= 500)
                    {
                        comission = 0.055;
                    }
                    else if (sellings > 500 && sellings <= 1000)
                    {
                        comission = 0.08;
                    }
                    else if (sellings > 1000 && sellings <= 10000)
                    {
                        comission = 0.12;
                    }
                    else if (sellings > 10000)
                    {
                        comission = 0.145;
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

            Console.WriteLine($"{(sellings * comission):F2}" );
        }
    }
}
