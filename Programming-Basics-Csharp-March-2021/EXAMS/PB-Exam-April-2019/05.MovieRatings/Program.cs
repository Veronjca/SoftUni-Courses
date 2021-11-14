using System;

namespace MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int movies = int.Parse(Console.ReadLine());

            string nameHighest = "";
            string nameLowest = "";
            double averageRating = 0;

            double highest = double.MinValue;
            double lowest = double.MaxValue;

            for (int i = 0; i < movies; i++)
            {
                string name = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                if (rating > highest)
                {
                    nameHighest = name;
                    highest = rating;
                }
                else if (rating < lowest)
                {
                    nameLowest = name;
                    lowest = rating;
                }

                 averageRating += rating;
            }

            double totalAverageRating = averageRating / movies;

            Console.WriteLine($"{nameHighest} is with highest rating: {highest:f1}");
            Console.WriteLine($"{nameLowest} is with lowest rating: {lowest:f1}");
            Console.WriteLine($"Average rating: {totalAverageRating:f1}");
        }
    }
}
