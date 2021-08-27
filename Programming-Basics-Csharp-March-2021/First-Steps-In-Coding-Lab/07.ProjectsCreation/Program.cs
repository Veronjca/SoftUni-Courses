using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architectName = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());
            int timeNeeded = 3;

            int result = numberOfProjects * timeNeeded;
            Console.WriteLine($"The architect {architectName} will need {result} hours to complete {numberOfProjects} project/s.");

        }
    }
}
