using System;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            byte numberOfRows = byte.Parse(Console.ReadLine());

            char[][] map = new char[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                map[i] = Console.ReadLine().ToCharArray();
            }

            int playerRow = 0;
            int playerCol = 0;
            bool flag = false;

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'A')
                    {
                        playerCol = j;
                        playerRow = i;
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            while (true)
            {
                string[] arguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = arguments[0];
                int enemyRow = int.Parse(arguments[1]);
                int enemyCol = int.Parse(arguments[2]);
                map[enemyRow][enemyCol] = 'O';
                map[playerRow][playerCol] = '-';
                armor--;

                if (direction == "up" && IsInside(playerRow, playerCol, map, direction))
                {                    
                    playerRow--;
                }
                else if (direction == "down" && IsInside(playerRow, playerCol, map, direction))
                {
                    playerRow++;
                }
                else if (direction == "right" && IsInside(playerRow, playerCol, map, direction))
                {
                    playerCol++;
                }
                else if (direction == "left" && IsInside(playerRow, playerCol, map, direction))
                {
                    playerCol--;
                }

                if (map[playerRow][playerCol] == 'M')
                {
                    map[playerRow][playerCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (map[playerRow][playerCol] != 'O')
                {
                    map[playerRow][playerCol] = 'A';
                }
                else
                {
                    armor -= 2;
                    if (armor <= 0)
                    {
                        map[playerRow][playerCol] = 'X';
                        Console.WriteLine($"The army was defeated at {playerRow};{playerCol}.");
                        break;
                    }
                    else
                    {
                        map[playerRow][playerCol] = 'A';
                    }
                }
            }
            foreach (var item in map)
            {
                Console.WriteLine(item);
            }
        }

        private static bool IsInside(int row, int col, char[][] map, string direction)
        {
            if (direction == "up")
            {
                row--;
                return row >= 0 && row < map.GetLength(0);
            }
            else if (direction == "down")
            {
                row++;
                return row >= 0 && row < map.GetLength(0);
            }
            else if (direction == "left")
            {
                col--;
                return col >= 0 && col < map[row].Length;
            }
            else
            {
                col++;
                return col >= 0 && col < map[row].Length;
            }
        }
    }
}
