using System;

namespace Voleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            // брой празници в годината (които не са събота и неделя).
            double holidays = int.Parse(Console.ReadLine());
            // брой уикенди, в които Влади си пътува до родния град.
            double weekendsInHomeTown = int.Parse(Console.ReadLine());

            double weekends = 48;
            // игри през празниците
            double holidayGames = holidays * 2/3;
            // игри в София
            double sofiaGames = (weekends - weekendsInHomeTown) * 3/4;

            double totalGames = holidayGames + sofiaGames + weekendsInHomeTown;

            switch (yearType)
            {
                case "leap":
                    totalGames *= 1.15;
                    break;
            }

            Console.WriteLine($"{Math.Floor(totalGames)}");
        }
    }
}
