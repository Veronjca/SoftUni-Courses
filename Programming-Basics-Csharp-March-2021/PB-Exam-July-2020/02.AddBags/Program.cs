using System;

namespace AddBags
{
    class Program
    {
        static void Main(string[] args)
        {
            double luggageOver20KilosPrice = double.Parse(Console.ReadLine());
            double luggageKilos = double.Parse(Console.ReadLine());
            double daysToTrip = double.Parse(Console.ReadLine());
            //Брой багажи – цяло число в диапазона [1…10]
            double luggageAmount = double.Parse(Console.ReadLine());

            double price = 0;

            if (luggageKilos < 10)
            {
                price = luggageOver20KilosPrice * 0.2;
            }
            else if (luggageKilos >= 10 && luggageKilos <= 20)
            {
                price = luggageOver20KilosPrice * 0.5;
            }
            else
            {
                price = luggageOver20KilosPrice;
            }

            if (daysToTrip > 30)
            {
                price += price * 0.1;
            }
            else if (daysToTrip >= 7 && daysToTrip <= 30)
            {
                price += price * 0.15;
            }
            else
            {
                price += price * 0.4;
            }

            double totalPrice = price * luggageAmount;

            Console.WriteLine($"The total price of bags is: {totalPrice:F2} lv. ");
        }
    }
}