using System;

namespace PBExamJune2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string serialName = Console.ReadLine();
            double seasons = double.Parse(Console.ReadLine());
            double episodes = double.Parse(Console.ReadLine());
            double duration = double.Parse(Console.ReadLine());

            double episodesDuration = ((seasons * episodes) - seasons) * duration; 
            double advertDuration = (duration * 0.2) * (seasons * episodes);
            double specialEpisodeTotalDuration = seasons * (duration + 10);

            double timeNeeded = episodesDuration + advertDuration + specialEpisodeTotalDuration;

            Console.WriteLine($"Total time needed to watch the {serialName} series is {Math.Round(timeNeeded)} minutes.");

        }
    }
}
