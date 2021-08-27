using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double timeNeeded = (pages / pagesPerHour) / days;

            Console.WriteLine(timeNeeded);


        }
    }
}
