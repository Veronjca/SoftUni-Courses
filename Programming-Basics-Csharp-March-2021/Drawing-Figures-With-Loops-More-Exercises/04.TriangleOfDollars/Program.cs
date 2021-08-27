using System;

namespace _04.TriangleOfDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int rows = 1; rows <= input; rows++)
            {
                int counter = 0;
                for (int cols = 0; cols < rows; cols++)
                {
                    Console.Write("$ ");
                    counter++;

                    if (counter >= rows)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
