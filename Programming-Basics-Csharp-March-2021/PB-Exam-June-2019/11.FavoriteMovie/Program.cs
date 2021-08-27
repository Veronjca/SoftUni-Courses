using System;

namespace FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            int counter = 0;
            double maxPoints = double.MinValue;
            string bestMovie = "";

            while (movieName != "STOP")
            {
                double points = 0;

                for (int i = 0; i < movieName.Length; i++)
                {
                    int symbol = movieName[i];
                    points += symbol;

                    if (symbol >= 97 && symbol <= 122)
                    {
                        points -= movieName.Length * 2;
                    }
                    if (symbol >= 65 && symbol <= 90)
                    {
                        points -= movieName.Length;
                    }                 
                }

                if (points > maxPoints)
                {
                    maxPoints = points;
                    bestMovie = movieName;
                }

                counter++;

                if (counter >= 7 )
                {
                    Console.WriteLine("The limit is reached.");
                    Console.WriteLine($"The best movie for you is {bestMovie} with {maxPoints} ASCII sum.");
                    return;
                }
                movieName = Console.ReadLine();
            }

            Console.WriteLine($"The best movie for you is {bestMovie} with {maxPoints} ASCII sum.");
        }
    }
}
