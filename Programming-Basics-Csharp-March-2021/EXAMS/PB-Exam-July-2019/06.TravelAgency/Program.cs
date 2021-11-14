using System;

namespace TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string packetType = Console.ReadLine();
            string VIP = Console.ReadLine();
            double days = double.Parse(Console.ReadLine());

            double price = 0;

            switch (city)
            {
                case "Bansko":
                case "Borovets":
                    switch (packetType)
                    {
                        case "noEquipment":
                            price = 80;
                            if (VIP == "yes")
                            {
                                price -= price * 0.05;
                            }
                            break;
                        case "withEquipment":
                            price = 100;
                            if (VIP == "yes")
                            {
                                price -= price * 0.10;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            return;
                            break;
                    }
                    break;
              
                case "Varna":
                case "Burgas":
                    switch (packetType)
                    {
                        case "noBreakfast":
                            price = 100;
                            if (VIP == "yes")
                            {
                                price -= price * 0.07;
                            }
                            break;
                        case "withBreakfast":
                            price = 130;
                            if (VIP == "yes")
                            {
                                price -= price * 0.12;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            return;
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    return;
                    break;

            }

            double totalPrice = days * price;

            if (days > 7)
            {
                totalPrice = (days - 1) * price;
            }

            if (days < 1)
            {
                Console.WriteLine($"Days must be positive number!");
            }
            else
            {
                Console.WriteLine($"The price is {totalPrice:f2}lv! Have a nice time!");
            }
        }
    }
}
