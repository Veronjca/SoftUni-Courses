using System;

namespace AluminumJoinery
{
    class Program
    {
        static void Main(string[] args)
        {
            double windowsCount = double.Parse(Console.ReadLine());
            string windowsType = Console.ReadLine();
            string delivery = Console.ReadLine();

            double price = 0;

            switch (windowsType)
            {
                case "90X130":
                    price = 110;
                    if (windowsCount >= 30 && windowsCount <= 60)
                    {
                        price -= price * 0.05;
                    }
                    else if (windowsCount > 60)
                    {
                        price -= price * 0.08;
                    }
                    break;
                case "100X150":
                    price = 140;
                    if (windowsCount >= 40 && windowsCount <= 80)
                    {
                        price -= price * 0.06;
                    }
                    else if (windowsCount > 80)
                    {
                        price -= price * 0.1;
                    }
                    break;
                case "130X180":
                    price = 190;
                    if (windowsCount >= 20 && windowsCount <= 50)
                    {
                        price -= price * 0.07;
                    }
                    else if (windowsCount > 50)
                    {
                        price -= price * 0.12;
                    }
                    break;
                case "200X300":
                    price = 250;
                    if (windowsCount >= 25 && windowsCount <= 50)
                    {
                        price -= price * 0.09;
                    }
                    else if (windowsCount > 50)
                    {
                        price -= price * 0.14;
                    }
                    break;
            }

            double totalPrice = price * windowsCount;

            switch (delivery)
            {
                case "With delivery":
                    totalPrice += 60;
                    if (windowsCount > 99)
                    {
                        totalPrice -= totalPrice * 0.04;
                    }
                    break;
                case "Without delivery":
                    if (windowsCount > 99)
                    {
                        totalPrice -= totalPrice * 0.04;
                    }
                    break;
            }

            if (windowsCount < 10)
            {
                Console.WriteLine("Invalid order");
            }
            else
            {
                Console.WriteLine($"{totalPrice:f2} BGN");
            }


        }
    }
}
