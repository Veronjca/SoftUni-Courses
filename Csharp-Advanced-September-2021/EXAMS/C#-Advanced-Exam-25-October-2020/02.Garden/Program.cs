using System;
using System.Collections.Generic;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(dimensions[0]);
            int columns = int.Parse(dimensions[1]);

            int[][] garden = new int[rows][];
            FillMatrix(rows, garden);
            List<(int row, int col)> flowersCoordinates = new List<(int row, int col)>();


            while (true)
            {
                string[] coordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (string.Join(' ', coordinates) == "Bloom Bloom Plow")
                {
                    break;
                }
                int row = int.Parse(coordinates[0]);
                int col = int.Parse(coordinates[1]);
                if (!IsInside(row, col, garden))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                flowersCoordinates.Add((row, col));
            }

            for (int i = 0; i < flowersCoordinates.Count; i++)
            {
                int currentRow = flowersCoordinates[i].row;
                int currentCol = flowersCoordinates[i].col;
                garden[currentRow][currentCol] = -1;
                for (int j = 0; j < garden[currentRow].Length; j++)
                {
                    garden[currentRow][j]++;
                }
                for (int k = 0; k < columns; k++)
                {
                    garden[k][currentCol]++;
                }
            }

            PrintMatrix(garden);
        }

        private static void PrintMatrix(int[][] garden)
        {
            foreach (var item in garden)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }

        private static bool IsInside(int row, int col, int[][] garden)
        {
            return row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden[row].Length;
        }

        private static void FillMatrix(int rows, int[][] garden)
        {
            for (int i = 0; i < rows; i++)
            {
                garden[i] = new int[rows];
            }
        }
    }
}
