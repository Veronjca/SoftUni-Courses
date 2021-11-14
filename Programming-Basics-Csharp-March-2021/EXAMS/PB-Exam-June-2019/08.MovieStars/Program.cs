using System;

namespace MovieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string actorName = Console.ReadLine();

            double salary = 0;

            while (actorName != "ACTION")
            {
                if (actorName.Length <= 15)
                {
                    salary = double.Parse(Console.ReadLine());
                }
                else
                {
                    salary = budget * 0.2;
                }

                budget -= salary;

                if (budget <= 0)
                {
                    break;
                }

                actorName = Console.ReadLine();
            }

            if (budget >= 0)
            {
                Console.WriteLine($"We are left with {Math.Abs(budget):f2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
            }
        }
    }
}
