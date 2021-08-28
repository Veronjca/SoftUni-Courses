using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {

            string playerName = Console.ReadLine();

            double maxGoals = 0;
            string name = "";

            while (playerName != "END")
            {
                
                double goals = double.Parse(Console.ReadLine());

                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    name = playerName;

                }
                

                if (goals >= 10)
                {
                    break;
                }


                playerName = Console.ReadLine();
            }

            Console.WriteLine($"{name} is the best player!");

            if (maxGoals >= 3)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!"); 
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
