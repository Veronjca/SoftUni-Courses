using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();


            int maxGoal = 0;
            string player = "";

            while (playerName != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if (goals > maxGoal)
                {
                    maxGoal = goals;
                    player = playerName;
                }
                if (goals >= 10)
                {
                    break;
                }

                playerName = Console.ReadLine();
            }

            Console.WriteLine($"{player} is the best player!");

            if (maxGoal >= 3)
            {
                Console.WriteLine($"He has scored {maxGoal} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoal} goals.");
            }
        }
    }
}
