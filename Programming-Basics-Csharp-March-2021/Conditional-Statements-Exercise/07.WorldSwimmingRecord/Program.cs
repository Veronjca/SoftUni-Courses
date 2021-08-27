using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldSwimmingRecord = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeNeededToSwimOneMeter = double.Parse(Console.ReadLine());

            double currentTime = distanceInMeters * timeNeededToSwimOneMeter;
            double slowing = Math.Floor(distanceInMeters / 15) * 12.5;

            double totalTime = currentTime + slowing;

            if (totalTime < worldSwimmingRecord)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                double timeNeeded = totalTime - worldSwimmingRecord;
                Console.WriteLine($"No, he failed! He was {timeNeeded:F2} seconds slower.");
            }

        }
    }
}
