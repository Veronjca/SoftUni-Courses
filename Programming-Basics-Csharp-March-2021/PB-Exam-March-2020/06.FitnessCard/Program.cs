using System;

namespace FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
           double money = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            double age = double.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double price = 0;

            switch (gender)
            {
                case 'm':
                    if (sport == "Gym")
                    {
                        price = 42;
                    }
                    else if (sport == "Boxing")
                    {
                        price = 41;
                    }
                    else if (sport == "Yoga")
                    {
                        price = 45;
                    }
                    else if (sport == "Zumba")
                    {
                        price = 34;
                    }
                    else if (sport == "Dances")
                    {
                        price = 51;
                    }
                    else
                    {
                        price = 39;
                    }
                    break;
                case 'f':
                    if (sport == "Gym")
                    {
                        price = 35;
                    }
                    else if (sport == "Boxing")
                    {
                        price = 37;
                    }
                    else if (sport == "Yoga")
                    {
                        price = 42;
                    }
                    else if (sport == "Zumba")
                    {
                        price = 31;
                    }
                    else if (sport == "Dances")
                    {
                        price = 53;
                    }
                    else
                    {
                        price = 37;
                    }
                    break;
            }

            double discount = 0;

            if (age <= 19)
            {
                discount = 0.2;
            }

            double totalDiscount = price * discount;
            double finalPrice = price - totalDiscount;

            if (money >= finalPrice)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${finalPrice - money:f2} more.");
            }
        }
    }
}
