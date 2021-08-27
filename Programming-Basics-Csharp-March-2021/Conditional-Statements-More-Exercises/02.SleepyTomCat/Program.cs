using System;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());

            double playingTimeInWorkdays = (365 - holidays) * 63;
            double playingTimeInHolidays = holidays * 127;

            double totalPlayingTime = playingTimeInHolidays + playingTimeInWorkdays;

            if (totalPlayingTime < 30000)
            {
                double timeInMinutes = (30000 - totalPlayingTime) % 60;
                double timeInHours = Math.Floor((30000 - totalPlayingTime) / 60);
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{timeInHours} hours and {timeInMinutes} minutes less for play");
            }
            else
            {
                double timeInMinutes2 = (totalPlayingTime - 30000) % 60;
                double timeInHours2 = Math.Floor((totalPlayingTime - 30000) / 60);
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{timeInHours2} hours and {timeInMinutes2} minutes more for play");
            }
         
        }
    }
}
