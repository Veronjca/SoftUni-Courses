using System;

namespace ArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {

            int day = int.Parse(Console.ReadLine());

            string[] daysOfTheWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (day > daysOfTheWeek.Length || day <= 0)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(daysOfTheWeek[day - 1]);
            }

          
        }
    }
}
