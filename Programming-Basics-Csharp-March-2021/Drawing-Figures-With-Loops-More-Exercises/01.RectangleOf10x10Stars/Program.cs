using System;

namespace DrawingFiguresWithLoopsMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            int counter = 0;

            for (int i = 1; i <= 100; i++)
            {
                Console.Write("*");

                counter++;
                if (counter % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
