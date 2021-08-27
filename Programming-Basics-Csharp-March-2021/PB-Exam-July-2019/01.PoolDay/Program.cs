using System;

namespace PBExamJuly2019
{
    class Program
    {
        static void Main(string[] args)
        {
            double people = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double loungePrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double totalTaxes = people * tax;
            double peopleWhoWantLounge = Math.Ceiling(people * 0.75);
            double peopleWhoWantUmbrella = Math.Ceiling(people / 2);

            double totalLoungePrice = peopleWhoWantLounge * loungePrice;
            double totalUmbrellaPrice = peopleWhoWantUmbrella * umbrellaPrice;

            double total = totalTaxes + totalLoungePrice + totalUmbrellaPrice;

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
