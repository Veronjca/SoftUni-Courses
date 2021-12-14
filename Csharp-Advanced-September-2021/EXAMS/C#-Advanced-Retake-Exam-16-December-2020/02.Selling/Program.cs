using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] bakery = new char[size][];
            FillMatrix(size, bakery);
            (int row, int col) coordinates = GetCoordinates(bakery);
            int money = 0;

            bakery[coordinates.row][coordinates.col] = '-';
            while (money < 50)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    coordinates.row--;
                    if (!IsInside(coordinates.row, coordinates.col, bakery))
                    {
                        break;
                    }
                    money = CheckClient(bakery, coordinates, money);
                    coordinates = CheckPillar(bakery, coordinates);
                }
                else if (command == "down")
                {
                    coordinates.row++;
                    if (!IsInside(coordinates.row, coordinates.col, bakery))
                    {
                        break;
                    }
                    money = CheckClient(bakery, coordinates, money);
                    coordinates = CheckPillar(bakery, coordinates);
                }
                else if (command == "left")
                {
                    coordinates.col--;
                    if (!IsInside(coordinates.row, coordinates.col, bakery))
                    {
                        break;
                    }
                    money = CheckClient(bakery, coordinates, money);
                    coordinates = CheckPillar(bakery, coordinates);
                }
                else if (command == "right")
                {
                    coordinates.col++;
                    if (!IsInside(coordinates.row, coordinates.col, bakery))
                    {
                        break;
                    }
                    money = CheckClient(bakery, coordinates, money);
                    coordinates = CheckPillar(bakery, coordinates);
                }
                bakery[coordinates.row][coordinates.col] = '-';
            }

            if (IsInside(coordinates.row, coordinates.col, bakery))
            {
                bakery[coordinates.row][coordinates.col] = 'S';
            }
           
            Console.WriteLine($"{(money >= 50 ? "Good news! You succeeded in collecting enough money!" : "Bad news, you are out of the bakery.")}");
            Console.WriteLine($"Money: {money}");
            PrintMatrix(bakery);
        }

        private static void PrintMatrix(char[][] bakery)
        {
            foreach (var item in bakery)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static (int row, int col) CheckPillar(char[][] bakery, (int row, int col) coordinates)
        {
            if (bakery[coordinates.row][coordinates.col] == 'O')
            {
                bakery[coordinates.row][coordinates.col] = '-';
                (int row, int col) secondPillarCoordinates = GetSecongPillarCoordinates(bakery);
                coordinates.row = secondPillarCoordinates.row;
                coordinates.col = secondPillarCoordinates.col;
            }

            return coordinates;
        }

        private static int CheckClient(char[][] bakery, (int row, int col) coordinates, int money)
        {
            if (char.IsDigit(bakery[coordinates.row][coordinates.col]))
            {
                money += int.Parse(bakery[coordinates.row][coordinates.col].ToString());
            }

            return money;
        }

        private static (int row, int col) GetSecongPillarCoordinates(char[][] bakery)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                for (int j = 0; j < bakery[i].Length; j++)
                {
                    if (bakery[i][j] == 'O')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return (row, col);
        }

        private static (int row, int col) GetCoordinates(char[][] bakery)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                for (int j = 0; j < bakery[i].Length; j++)
                {
                    if (bakery[i][j] == 'S')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return (row, col);
        }

        private static void FillMatrix(int size, char[][] bakery)
        {
            for (int i = 0; i < size; i++)
            {
                bakery[i] = Console.ReadLine().ToCharArray();
            }
        }

        private static bool IsInside(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}
