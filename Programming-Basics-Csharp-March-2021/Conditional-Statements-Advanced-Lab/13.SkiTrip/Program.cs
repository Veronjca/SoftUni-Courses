using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            double discount = 0;

            switch (roomType)
            {
                case "room for one person":
                    discount = 0;
                    break;
                case "apartment":
                    if (days < 10)
                    {
                        discount = 0.3;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.35;
                    }
                    else
                    {
                        discount = 0.5;
                    }
                    break;
                case "president apartment":
                    if (days < 10)
                    {
                        discount = 0.10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.15;
                    }
                    else
                    {
                        discount = 0.2;
                    }
                    break;
            }
            double roomPrice = 0;

            switch (roomType)
            {
                case "room for one person":
                    roomPrice = (days - 1) * (18 - (18 * discount));
                    break;
                case "apartment":
                    roomPrice = (days - 1) * (25 - (25 * discount));
                    break;
                case "president apartment":
                    roomPrice = (days - 1) * (35 - (35 * discount));
                    break;
            }

            double totalRoomPrice = 0;

            if (rating == "positive")
            {
                totalRoomPrice = roomPrice + (roomPrice * 0.25);
            }
            else
            {
                totalRoomPrice = roomPrice - (roomPrice * 0.10);
            }

            Console.WriteLine($"{totalRoomPrice:F2}");
        }
    }
}
