using System;

namespace _02.Armory
{
    class Program
    {


        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] armory = new char[size][];

            FillMatrix(size, armory);
            (int row, int col) coordinates = GetCoordinates(armory);

            int money = 0;
            armory[coordinates.row][coordinates.col] = '-';
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    coordinates.row--;
                    if (!IsInside(coordinates.row, coordinates.col, armory))
                    {
                        break;
                    }
                    money = CheckSword(armory, coordinates, money);
                    coordinates = CheckMirror(armory, coordinates);
                }
                else if (command == "down")
                {
                    coordinates.row++;
                    if (!IsInside(coordinates.row, coordinates.col, armory))
                    {
                        break;
                    }
                    money = CheckSword(armory, coordinates, money);
                    coordinates = CheckMirror(armory, coordinates);
                }
                else if (command == "left")
                {
                    coordinates.col--;
                    if (!IsInside(coordinates.row, coordinates.col, armory))
                    {
                        break;
                    }
                    money = CheckSword(armory, coordinates, money);
                    coordinates = CheckMirror(armory, coordinates);
                }
                else if (command == "right")
                {
                    coordinates.col++;
                    if (!IsInside(coordinates.row, coordinates.col, armory))
                    {
                        break;
                    }
                    money = CheckSword(armory, coordinates, money);
                    coordinates = CheckMirror(armory, coordinates);
                }
                if (money >= 65)
                {
                    break;
                }
            }

            if (!IsInside(coordinates.row, coordinates.col, armory))
            {               
                Console.WriteLine("I do not need more swords!");               
            }
            else
            {
                armory[coordinates.row][coordinates.col] = 'A';
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {money} gold coins.");
            PrintMatrix(armory);
        }
        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
        private static (int row, int col) GetSecondMirrorCoordinates(char[][] armory)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < armory.GetLength(0); i++)
            {
                for (int j = 0; j < armory[i].Length; j++)
                {
                    if (armory[i][j] == 'M')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            armory[row][col] = '-';
            return (row, col);
        }
        private static (int row, int col) CheckMirror(char[][] armory, (int row, int col) coordinates)
        {
            if (armory[coordinates.row][coordinates.col] == 'M')
            {
                armory[coordinates.row][coordinates.col] = '-';
                (int row, int col) secondPillarCoordinates = GetSecondMirrorCoordinates(armory);
                coordinates.row = secondPillarCoordinates.row;
                coordinates.col = secondPillarCoordinates.col;
            }

            return coordinates;
        }
        private static int CheckSword(char[][] armory, (int row, int col) coordinates, int money)
        {
            if (char.IsDigit(armory[coordinates.row][coordinates.col]))
            {               
                money += int.Parse(armory[coordinates.row][coordinates.col].ToString());
                armory[coordinates.row][coordinates.col] = '-';
            }

            return money;
        }
        private static (int row, int col) GetCoordinates(char[][] armory)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < armory.GetLength(0); i++)
            {
                for (int j = 0; j < armory[i].Length; j++)
                {
                    if (armory[i][j] == 'A')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return (row, col);
        }
        private static void FillMatrix(int size, char[][] armory)
        {
            for (int i = 0; i < size; i++)
            {
                armory[i] = Console.ReadLine().ToCharArray();
            }
        }
        private static bool IsInside(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}
