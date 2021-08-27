using System;

namespace NestedLoopsExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int current = 1;

            bool ifBigger = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (current > n )
                    {
                        ifBigger = true;
                        break;
                    }

                    Console.Write($"{current} ");
                    current++;
                }
                if (ifBigger)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
