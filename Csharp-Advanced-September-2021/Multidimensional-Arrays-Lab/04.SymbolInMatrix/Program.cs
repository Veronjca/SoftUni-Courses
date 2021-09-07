using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                input = String.Join(" ", input);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j].ToString();
                }
            }

            string symbol = Console.ReadLine();

            int row = int.MaxValue;
            int col = int.MaxValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        if (i < row)
                        {
                            row = i;
                        }
                        if (j < col)
                        {
                            col = j;
                        }
                    }
                }
            }

            if (row == int.MaxValue && col == int.MaxValue)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
            else
            {
                Console.WriteLine($"({row}, {col})");
            }
           
        }
    }
}
