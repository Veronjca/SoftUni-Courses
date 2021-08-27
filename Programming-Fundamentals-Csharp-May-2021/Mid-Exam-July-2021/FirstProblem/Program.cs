using System;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededExperience = int.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());

            double collectedExperience = 0;
            int counter = 0;


            for (int i = 1; i <= countOfBattles; i++)
            {
                counter++;
                double experienceEarnedPerBattle = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    experienceEarnedPerBattle += experienceEarnedPerBattle * 0.15;
                }
                else if (i % 5 == 0)
                {
                    experienceEarnedPerBattle -= experienceEarnedPerBattle * 0.1;
                }
                else if (i % 15 == 0)
                {
                    experienceEarnedPerBattle += experienceEarnedPerBattle * 0.05;
                }
                
                    collectedExperience += experienceEarnedPerBattle;
                

                if (collectedExperience >= neededExperience)
                {
                    break;
                }
            }

            if (collectedExperience >= neededExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {counter} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience - collectedExperience:f2} more needed.");
            }

        }
    }
}
