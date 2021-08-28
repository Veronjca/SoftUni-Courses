using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleInTheGroup = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayType = Console.ReadLine();

            double price = 0;

            switch (dayType)
            {
                case "Friday":
                    switch (groupType)
                    {
                        case "Students":
                            price = 8.45;
                            break;
                        case "Business":
                            price = 10.90;
                            break;
                        case "Regular":
                            price = 15;
                            break;
                    }
                    break;
                case "Saturday":
                    switch (groupType)
                    {
                        case "Students":
                            price = 9.80;
                            break;
                        case "Business":
                            price = 15.60;
                            break;
                        case "Regular":
                            price = 20;
                            break;
                    }
                    break;
                case "Sunday":
                    switch (groupType)
                    {
                        case "Students":
                            price = 10.46;
                            break;
                        case "Business":
                            price = 16;
                            break;
                        case "Regular":
                            price = 22.50;
                            break;
                    }
                    break;
            }

            double totalPrice = peopleInTheGroup * price;

            if (peopleInTheGroup >= 30 && groupType == "Students")
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (peopleInTheGroup >= 100 && groupType == "Business")
            {
                totalPrice -= (price * 10);
            }
            else if (peopleInTheGroup >= 10 && peopleInTheGroup <= 20 && groupType == "Regular")
            {
                totalPrice -= totalPrice * 0.05;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
