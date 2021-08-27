using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string command = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double price = 0;

            switch (drink)
            {
                case "Espresso":
                    switch (command)
                    {
                        case "Without":
                            price = 0.9;
                            break;
                        case "Normal":
                            price = 1.00;
                            break;
                        case "Extra":
                            price = 1.20;
                            break;
                    } 
                    break;
                case "Cappuccino":
                    switch (command)
                    {
                        case "Without":
                            price = 1.00;
                            break;
                        case "Normal":
                            price = 1.20;
                            break;
                        case "Extra":
                            price = 1.60;
                            break;
                    }
                    break;

                case "Tea":
                    switch (command)
                    {
                        case "Without":
                            price = 0.50;
                            break;
                        case "Normal":
                            price = 0.60;
                            break;
                        case "Extra":
                            price = 0.70;
                            break;
                    }
                    break;
            }

            double totalPrice = amount * price;

            if (command == "Without")
            {
                totalPrice -= totalPrice * 0.35;
            }

            if (drink == "Espresso" && amount >= 5)
            {
                totalPrice -= totalPrice * 0.25;
            }

            if (totalPrice > 15)
            {
                totalPrice -= totalPrice * 0.20;
            }

            Console.WriteLine($"You bought {amount} cups of {drink} for {totalPrice:f2} lv.");
        }
    }
}
