using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            (int row, int col) coordinates = FindPlayerCoordinates(matrix);

            matrix[coordinates.row][coordinates.col] = '-';
            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();
                if (command == "up" && IsInside(coordinates.row - 1, coordinates.col, matrix))
                {
                    if (matrix[coordinates.row - 1][coordinates.col] == 'B')
                    {
                        coordinates.row -= 2;
                    }
                    else if (matrix[coordinates.row - 1][coordinates.col] != 'T')
                    {
                        coordinates.row--;
                    }
                }
                else if (command == "up" && !IsInside(coordinates.row - 1, coordinates.col, matrix))
                {
                    if (matrix[size - 1][coordinates.col] == 'B')
                    {
                        coordinates.row = size - 2;
                    }
                    else if (matrix[size - 1][coordinates.col] != 'T')
                    {
                        coordinates.row = size - 1;
                    }
                }
                else if (command == "down" && IsInside(coordinates.row + 1, coordinates.col, matrix))
                {
                    if (matrix[coordinates.row + 1][coordinates.col] == 'B')
                    {
                        coordinates.row += 2;
                    }
                    else if (matrix[coordinates.row + 1][coordinates.col] != 'T')
                    {
                        coordinates.row++;
                    }
                }
                else if (command == "down" && !IsInside(coordinates.row + 1, coordinates.col, matrix))
                {
                    if (matrix[0][coordinates.col] == 'B')
                    {
                        coordinates.row = 1;
                    }
                    else if (matrix[0][coordinates.col] != 'T')
                    {
                        coordinates.row = 0;
                    }
                }
                else if (command == "right" && IsInside(coordinates.row, coordinates.col + 1, matrix))
                {
                    if (matrix[coordinates.row][coordinates.col + 1] == 'B')
                    {
                        coordinates.col += 2;
                    }
                    else if (matrix[coordinates.row][coordinates.col + 1] != 'T')
                    {
                        coordinates.col++;
                    }
                }
                else if (command == "right" && !IsInside(coordinates.row, coordinates.col + 1, matrix))
                {
                    if (matrix[coordinates.row][0] == 'B')
                    {
                        coordinates.col = 1;
                    }
                    else if (matrix[coordinates.row][0] != 'T')
                    {
                        coordinates.col = 0;
                    }
                }
                else if (command == "left" && !IsInside(coordinates.row, coordinates.col - 1, matrix))
                {
                    if (matrix[coordinates.row][matrix[coordinates.row].Length - 1] == 'B')
                    {
                        coordinates.col = matrix[coordinates.row].Length - 2;
                    }
                    else if (matrix[coordinates.row][matrix[coordinates.row].Length - 1] != 'T')
                    {
                        coordinates.col = matrix[coordinates.row].Length - 1;
                    }
                }
                else if (command == "left" && IsInside(coordinates.row, coordinates.col - 1, matrix))
                {
                    if (matrix[coordinates.row][coordinates.col - 1] == 'B')
                    {
                        if (IsInside(coordinates.row, coordinates.col - 2, matrix))
                        {
                            coordinates.col -= 2;
                        }
                        else
                        {
                            coordinates.col = matrix[coordinates.row].Length - 1;
                        }

                    }
                    else if (matrix[coordinates.row][coordinates.col - 1] != 'T')
                    {
                        coordinates.col--;
                    }
                }

                IsWon(matrix, (coordinates.row, coordinates.col));
            }

            matrix[coordinates.row][coordinates.col] = 'f';
            Console.WriteLine("Player lost!");
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static void IsWon(char[][] matrix, (int row, int col) coordinates)
        {
            if (matrix[coordinates.row][coordinates.col] == 'F')
            {
                matrix[coordinates.row][coordinates.col] = 'f';
                Console.WriteLine("Player won!");
                foreach (var item in matrix)
                {
                    Console.WriteLine(string.Join("", item));
                }
                Environment.Exit(0);
            }
        }

        private static (int playerRow, int playerCol) FindPlayerCoordinates(char[][] matrix)
        {
            bool flag = false;
            int playerRow = 0;
            int playerCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }

            return (playerRow, playerCol);
        }

        private static bool IsInside(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}
