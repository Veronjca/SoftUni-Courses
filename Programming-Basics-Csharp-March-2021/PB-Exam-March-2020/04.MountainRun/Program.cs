using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeNeededFor1Meter = double.Parse(Console.ReadLine());

            double time = timeNeededFor1Meter * distance;
            double slowing = Math.Floor(distance / 50) * 30;

            double totalTime = time + slowing;

            if (totalTime < record)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {totalTime - record:f2} seconds slower.");
            }
        }
    }
}
