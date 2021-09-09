using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] jagged = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = new long[i + 1];
                jagged[i][0] = 1;
                jagged[i][jagged[i].Length-1] = 1;
                


                for (int j = 1; j < i; j++)
                {
                    jagged[i][j] = jagged[i - 1][j] + jagged[i - 1][j - 1];
                }

            }

            foreach (var item in jagged)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
