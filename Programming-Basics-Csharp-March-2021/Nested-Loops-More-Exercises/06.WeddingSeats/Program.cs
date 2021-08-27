using System;

namespace WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rowsInSectorA = int.Parse(Console.ReadLine());
            int seatsOdd = int.Parse(Console.ReadLine());

            int seatsEven = seatsOdd + 2;
            int totalGuests = 0;

            for (int i = 65; i <= sector; i++)
            {
                for (int j = 1; j <= rowsInSectorA; j++)
                {
                    int currentSeats = j % 2 == 0 ? seatsEven : seatsOdd;

                    for (int k = 'a'; k < 'a' + currentSeats; k++)
                    {
                        Console.WriteLine($"{(char)i}{j}{(char)k}");
                        totalGuests++;
                    }

                } 

                rowsInSectorA++;
            }

            Console.WriteLine(totalGuests);
        }
    }
}

