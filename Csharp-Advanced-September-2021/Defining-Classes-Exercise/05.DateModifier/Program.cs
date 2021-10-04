using System;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {

            string firstDate;
            string secondDate;

            DateModifier dates = new DateModifier(secondDate = Console.ReadLine(), firstDate = Console.ReadLine());

            double diff = dates.Difference(dates.FirstDate, dates.SecondDate);

            Console.WriteLine(diff);

        }
    }
}
