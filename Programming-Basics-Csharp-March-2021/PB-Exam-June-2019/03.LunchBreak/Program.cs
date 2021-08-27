using System;

namespace LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            double episodeDuration = double.Parse(Console.ReadLine());
            double restDuration = double.Parse(Console.ReadLine());

            double lunchDuration = (restDuration * 1 / 8);
            double relaxDuration = (restDuration * 1 / 4);

            double timeNeeded = episodeDuration + lunchDuration + relaxDuration;

            if (restDuration >= timeNeeded)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(restDuration - timeNeeded)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(timeNeeded - restDuration)} more minutes.");
            }
        }
    }
}
