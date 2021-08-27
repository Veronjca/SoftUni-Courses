using System;

namespace FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstGameResult = Console.ReadLine();
            string secondGameResult = Console.ReadLine();
            string thirdGameResult = Console.ReadLine();

            double win = 0;
            double lose = 0;
            double drawn = 0;

            if (firstGameResult[0] > firstGameResult[2])
            {
                win++;
            }
            else if (firstGameResult[0] < firstGameResult[2])
            {
                lose++;
            }
            else if (firstGameResult[0] == firstGameResult[2])
            {
                drawn++;
            }

            if (secondGameResult[0] > secondGameResult[2])
            {
                win++;
            }
            else if (secondGameResult[0] < secondGameResult[2])
            {
                lose++;
            }
            else if (secondGameResult[0] == secondGameResult[2])
            {
                drawn++;
            }

            if (thirdGameResult[0] > thirdGameResult[2])
            {
                win++;
            }
            else if (thirdGameResult[0] < thirdGameResult[2])
            {
                lose++;
            }
            else if (thirdGameResult[0] == thirdGameResult[2])
            {
                drawn++;
            }

            Console.WriteLine($"Team won {win} games.");
            Console.WriteLine($"Team lost {lose} games.");
            Console.WriteLine($"Drawn games: {drawn}");
            
        }
    }
}
