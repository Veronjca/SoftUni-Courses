using System;

namespace ComputerName
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double hours = double.Parse(Console.ReadLine());
            double peopleInOneGroup = double.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            double price = 0;

            switch (time)
            {
                case "day":
                    switch (month)
                    {
                        case "march":
                        case "april":
                        case "may":
                            price = 10.50;
                            break;
                        case "june":
                        case "july":
                        case "august":
                            price = 12.60;
                            break;
                    }
                    break;

                case "night":
                    switch (month)
                    {
                        case "march":
                        case "april":
                        case "may":
                            price = 8.40;
                            break;
                        case "june":
                        case "july":
                        case "august":
                            price = 10.20;
                            break;
                    }
                    break;
            }

            if (peopleInOneGroup >= 4)
            {
                price = price - price * 0.1;
            }

            if (hours >= 5)
            {
                price = price - price * 0.5;
            }

            

            double totalPrice = hours * price;
            double finalPrice = peopleInOneGroup * totalPrice;

            Console.WriteLine($"Price per person for one hour: {price:f2}");
            Console.WriteLine($"Total cost of the visit: {finalPrice:f2}");
        }
    }
}
