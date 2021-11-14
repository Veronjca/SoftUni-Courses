using System;

namespace CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            double minutesWalkingPerDay = double.Parse(Console.ReadLine());
            double walkingsPerDay = double.Parse(Console.ReadLine());
            double calories = double.Parse(Console.ReadLine());

            double totalMinutesWalking = minutesWalkingPerDay * walkingsPerDay;

            double burnedCal = totalMinutesWalking * 5;
            double neededCal = calories / 2;

            if (burnedCal >= neededCal)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnedCal}.");
            }
            else
            {

                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnedCal}.");

            }
        }
    }
}
