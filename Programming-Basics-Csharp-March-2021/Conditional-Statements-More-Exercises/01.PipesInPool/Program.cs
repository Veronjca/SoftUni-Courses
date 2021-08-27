using System;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            //Обем на басейна в литри 
            int V = int.Parse(Console.ReadLine());
            //дебит на първата тръба за час 
            int P1 = int.Parse(Console.ReadLine());
            //дебит на втората тръба за час
            int P2 = int.Parse(Console.ReadLine());
            //часовете които работникът отсъства 
            double H = double.Parse(Console.ReadLine());

            //състоянието на басейна, в момента, когато работникът се върне. 
            double poolStatus = (P1 + P2) * H;

            double poolPercentage = (poolStatus / V) * 100;
            double firstPipePercentage = P1 * H * 100/ poolStatus;
            double secondPipePercentage = P2 * H * 100/ poolStatus;

            if ( poolStatus <= V)
            {
                Console.WriteLine($"The pool is {poolPercentage:F2} % full.Pipe 1:{firstPipePercentage:F2}%.Pipe 2:{ secondPipePercentage:F2}%.");
            }

            else 
            {
                double poolFullness = poolStatus - V;
                Console.WriteLine($"For {H:F2} hours the pool overflows with {poolFullness:F2} liters.");
            }
        }
    }
}
