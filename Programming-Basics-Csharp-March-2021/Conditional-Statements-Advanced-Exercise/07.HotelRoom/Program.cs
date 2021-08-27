using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int overnight = int.Parse(Console.ReadLine());

            double apartmentPrice = 0;
            double studioPrice = 0;
            double discountStudio = 0;
            double discountApartment = 0;

            switch (month)
            {
                case "May":
                case "October":
                    if (overnight > 7 && overnight < 14)
                    {
                        discountStudio = (overnight * 50) * 0.05;
                        apartmentPrice = overnight * 65;
                        studioPrice = overnight * 50 - discountStudio;
                    }
                    else if (overnight > 14)
                    {
                        discountStudio = (overnight * 50) * 0.3;
                        discountApartment = (overnight * 65) * 0.1;
                        studioPrice = (overnight * 50) - discountStudio;
                        apartmentPrice = (overnight * 65) - discountApartment;
                    }
                    else
                    {
                        studioPrice = overnight * 50;
                        apartmentPrice = overnight * 65;
                    }
                    break;
                case "June":
                case "September":
                    if (overnight > 14)
                    {
                        discountApartment = (overnight * 68.70) * 0.1;
                        discountStudio = (overnight * 75.20) * 0.2;
                        studioPrice = overnight * 75.20 - discountStudio;
                        apartmentPrice = overnight * 68.70 - discountApartment;
                    }
                    else
                    {
                        studioPrice = overnight * 75.20;
                        apartmentPrice = overnight * 68.70;
                    }
                    break;
                case "July":
                case "August":
                    if (overnight > 14)
                    {
                        discountApartment = (overnight * 77) * 0.1;
                        apartmentPrice = overnight * 77 - discountApartment;
                        studioPrice = overnight * 76;
                    }
                    else
                    {
                        apartmentPrice = overnight * 77;
                        studioPrice = overnight * 76;
                    }
                    break;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice:F2} lv.");

        }
    }
}
