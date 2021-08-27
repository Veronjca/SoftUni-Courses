using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double hoursNeeded = int.Parse(Console.ReadLine());
            double days = int.Parse(Console.ReadLine());
            //броят на служителите, работещи извънредно  
            double workers = int.Parse(Console.ReadLine());

            double training = days * 0.1;
            // работните часове
            double workingHours = Math.Floor((days - training) * 8);
            // извънредните часове
            double additionalWorkingHours = Math.Floor((days * 2) * workers);

            double totalHours = (workingHours + additionalWorkingHours);

            if (totalHours >= hoursNeeded)
            {
                double hoursLeft = Math.Floor(totalHours - hoursNeeded);
                Console.WriteLine($"Yes!{(hoursLeft)} hours left.");
            }

            else
            {
                
                Console.WriteLine($"Not enough time!{(hoursNeeded - totalHours)} hours needed.");
            }

        }
    }
}
