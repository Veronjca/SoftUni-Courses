using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] beeTerritory = new char[n][];
            FillMatrix(n, beeTerritory);
            (int row, int col) coordinates = FindBeeCoordinates(beeTerritory);
            beeTerritory[coordinates.row][coordinates.col] = '.';

            int pollinatedFlowers = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {              
                if (command == "up")
                {
                    coordinates.row--;
                }
                else if (command == "down")
                {
                    coordinates.row++;
                }
                else if (command == "left")
                {
                    coordinates.col--;
                }
                else if (command == "right")
                {
                    coordinates.col++;
                }

                if (!IsInside(coordinates.row, coordinates.col, beeTerritory))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                coordinates = BonusMove(command, coordinates, beeTerritory);
                pollinatedFlowers = IsFlower(beeTerritory, coordinates, pollinatedFlowers);
            }

            if (IsInside(coordinates.row, coordinates.col, beeTerritory))
            {
                beeTerritory[coordinates.row][coordinates.col] = 'B';
            }
            Console.WriteLine(pollinatedFlowers >= 5 ? $"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!" : $"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            PrintMatrix(beeTerritory);
        }

        private static (int, int) BonusMove(string command, (int row, int col) coordinates, char[][] beeTerritory)
        {
            if (beeTerritory[coordinates.row][coordinates.col] == 'O')
            {
                beeTerritory[coordinates.row][coordinates.col] = '.';
                switch (command)
                {
                    case "up":
                        coordinates.row--;
                        break;
                    case "down":
                        coordinates.row++;
                        break;
                    case "left":
                        coordinates.col--;
                        break;
                    case "right":
                        coordinates.col++;
                        break;
                }
            }
            return (coordinates.row, coordinates.col);
        }

        private static void PrintMatrix(char[][] beeTerritory)
        {
            foreach (var item in beeTerritory)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static int IsFlower(char[][] beeTerritory, (int row, int col) coordinates, int pollinatedFlowers)
        {
            if (beeTerritory[coordinates.row][coordinates.col] == 'f')
            {
                beeTerritory[coordinates.row][coordinates.col] = '.';
                pollinatedFlowers++;
            }

            return pollinatedFlowers;
        }

        private static bool IsInside(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }

        private static (int row, int col) FindBeeCoordinates(char[][] beeTerritory)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < beeTerritory.GetLength(0); i++)
            {
                for (int j = 0; j < beeTerritory[i].Length; j++)
                {
                    if (beeTerritory[i][j] == 'B')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return (row, col);
        }

        private static void FillMatrix(int n, char[][] beeTerritory)
        {
            for (int i = 0; i < n; i++)
            {
                beeTerritory[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
