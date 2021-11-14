using System;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
         

            double totalPoints = 0;
            double otherColors = 0;
            double redBalls = 0;
            double orangeBalls = 0;
            double yellowBalls = 0;
            double whiteBalls = 0;
            double blackBalls = 0;

            for (int i = 0; i < num; i++)
            {
                string color = Console.ReadLine();

                if (color == "red")
                {
                    redBalls++;
                    totalPoints += 5;
                }
                else if (color == "orange")
                {
                    orangeBalls++;
                    totalPoints += 10;
                }
               else if (color == "yellow")
                {
                    yellowBalls++;
                    totalPoints += 15;
                }
                else if (color == "white")
                {
                    whiteBalls++;
                    totalPoints += 20;
                }
                else if (color == "black")
                {
                    blackBalls++;
                    totalPoints = Math.Floor(totalPoints / 2);
                }
                else
                {
                    otherColors++;
                }

               
            }

            Console.WriteLine($"Total points: {totalPoints}"); 
            Console.WriteLine($"Points from red balls: {redBalls}");
            Console.WriteLine($"Points from orange balls: {orangeBalls}");
            Console.WriteLine($"Points from yellow balls: {yellowBalls}");
            Console.WriteLine($"Points from white balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherColors}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
