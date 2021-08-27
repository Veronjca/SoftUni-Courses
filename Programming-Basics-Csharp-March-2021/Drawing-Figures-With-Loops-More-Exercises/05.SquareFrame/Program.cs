using System;

namespace _05.SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            Console.Write("+ ");
            for (int i = 1; i <= input - 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+");

            for (int i = 1; i <= input - 2; i++)
            {
                Console.Write("| ");
                for (int j = 1; j <= input - 2; j++)
                {
                    Console.Write("- ");
                }
                Console.WriteLine("|");
            }

            Console.Write("+ ");
            for (int i = 1; i <= input - 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+");

        }
    }
}
