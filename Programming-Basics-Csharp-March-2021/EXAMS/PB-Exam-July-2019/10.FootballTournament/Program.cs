using System;

namespace FootballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            double matches = double.Parse(Console.ReadLine());

            double points = 0;

            double wins = 0;
            double losses = 0;
            double equals = 0;

            for (int i = 0; i < matches; i++)
            {
                string result = Console.ReadLine();

                if (result == "W")
                {
                    points += 3;
                    wins++;
                }
                else if (result == "D")
                {
                    points += 1;
                    equals++;
                }
                else if (result == "L")
                {
                    losses++;
                }
            }

            double winRate = (wins / matches) * 100;


            if (matches == 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
                return;
            }

            Console.WriteLine($"{teamName} has won {points} points during this season.");
            Console.WriteLine("Total stats:");
            Console.WriteLine($"## W: {wins}");
            Console.WriteLine($"## D: {equals}");
            Console.WriteLine($"## L: {losses}");
            Console.WriteLine($"Win rate: {winRate:f2}%");
        }
    }
}
