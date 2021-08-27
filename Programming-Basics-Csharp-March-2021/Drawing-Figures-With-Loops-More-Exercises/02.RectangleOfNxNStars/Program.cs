using System;

namespace _02.RectangleOfNxNStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 1; i <= input * input; i++)
            {
                Console.Write("*");
                counter++;

                if (counter % input == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
