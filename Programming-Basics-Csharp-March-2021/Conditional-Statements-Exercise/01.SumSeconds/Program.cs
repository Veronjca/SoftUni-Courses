using System;

namespace ConditionalStatementsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalTime = firstTime + secondTime + thirdTime;
            int totalTimeInMinutes = totalTime / 60;
            int seconds = totalTime % 60;

            if ( seconds <10)
            {
                Console.WriteLine($"{totalTimeInMinutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{totalTimeInMinutes}:{seconds}");
            }

        }
    }
}
