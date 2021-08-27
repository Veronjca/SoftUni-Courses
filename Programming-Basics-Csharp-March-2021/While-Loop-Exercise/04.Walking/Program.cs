using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            const int goal = 10_000;

            int totalSteps = 0;
            bool didReachTheGoal = false;

            while (command != "Going home")
            {
                int steps = int.Parse(command);
                totalSteps += steps;

                if (totalSteps >= 10000)
                {
                    didReachTheGoal = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (didReachTheGoal)
            {

                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - goal} steps over the goal!");
            }
            else
            {
                int aditionalSteps = int.Parse(Console.ReadLine());
                totalSteps += aditionalSteps;

                if (totalSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{totalSteps - goal} steps over the goal!");
                }
                else
                {
                    
                    Console.WriteLine($"{Math.Abs(totalSteps - goal)} more steps to reach goal.");
                }
            }
        }
    }
}
