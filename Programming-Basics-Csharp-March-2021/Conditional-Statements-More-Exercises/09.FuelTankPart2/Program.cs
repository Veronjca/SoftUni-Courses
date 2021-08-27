using System;

namespace FuelTankPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            string discountCard = Console.ReadLine();

            double discount = 0.0;
            double fuelPrice = 0.0;
            double finalFuelPrice = 0.0;

           if (fuelType == "Diesel")
            {
                discount = 0.12;
                fuelPrice = 2.33;
            }
           else if ( fuelType == "Gasoline")
            {
                discount = 0.18;
                fuelPrice = 2.22;
            }
           else if ( fuelType == "Gas")
            {
                discount = 0.08;
                fuelPrice = 0.93;
            }

           if (discountCard == "Yes")
            {
                finalFuelPrice = (liters * fuelPrice) - (liters * discount);
            }
           else
            {
                finalFuelPrice = liters * fuelPrice;
            }

           if ( liters >= 20 && liters <=25)
            {
                finalFuelPrice *= 0.92;
            }

           else if (liters > 25)
            {
                finalFuelPrice *= 0.90;
            }

            Console.WriteLine($"{finalFuelPrice:F2} lv.");
        }
    }
}
