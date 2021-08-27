using System;

namespace MovieDay
{
    class Program
    {
        static void Main(string[] args)
        {
            double shootingTime = double.Parse(Console.ReadLine());
            double scenes = double.Parse(Console.ReadLine());
            double scenesShootingTime = double.Parse(Console.ReadLine());

            double preparing = shootingTime * 0.15;

            double timeNeeded = (scenes * scenesShootingTime) + preparing;

            if (shootingTime >= timeNeeded)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(shootingTime - timeNeeded)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {timeNeeded - shootingTime} minutes.");
            }





        }
    }
}
