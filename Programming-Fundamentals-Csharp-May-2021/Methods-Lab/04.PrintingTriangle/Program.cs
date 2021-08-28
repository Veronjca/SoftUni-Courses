using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            PrintingTriangle(input);
        }

        private static void PrintingTriangle(int input)
        {
            for (int rows = 1; rows <= input; rows++)
            {
                Cols(rows);
            }

            for (int rows = input - 1; rows >= 1; rows--)
            {
                Cols(rows);
            }
        }

        private static void Cols(int rows)
        {
            for (int i = 1; i <= rows; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
