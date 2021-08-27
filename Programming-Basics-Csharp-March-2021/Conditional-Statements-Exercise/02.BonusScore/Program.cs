using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());

            double bonusScore = 0.0;

            if (score <= 100)
            {
                bonusScore = 5;
            }
            else if (score > 1000)
            {
                bonusScore = score * 0.1;
            }
            else 
            {
                bonusScore = score * 0.2;
            }

            double additionalBonusScore = 0.0;
            
            if (score % 2 == 0)
            {
                additionalBonusScore = 1;
            }

            else if (score % 10 == 5)
            {
                additionalBonusScore = 2;
            }

            Console.WriteLine(bonusScore + additionalBonusScore);
            Console.WriteLine(score + bonusScore + additionalBonusScore);
        }
    }
}
