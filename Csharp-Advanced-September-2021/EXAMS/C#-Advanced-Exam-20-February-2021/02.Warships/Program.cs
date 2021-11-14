using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            List<(int row, int col)> attackCoordinates = new List<(int row, int col)>();
            string[] attacks = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < attacks.Length; i++)
            {
                int[] current = attacks[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                attackCoordinates.Add((current[0], current[1]));
            }
            char[][] field = new char[size][];
            for (int i = 0; i < size; i++)
            {
                field[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();           
            }

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            for (int i = 0; i <field.GetLength(0) ; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (field[i][j] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            Dictionary<string, int> info = new Dictionary<string, int>();
            info.Add("firstPlayerShips", firstPlayerShips);
            info.Add("secondPlayerShips", secondPlayerShips);
            info.Add("sunkShips", 0);

            while (attackCoordinates.Count > 0)
            {
                int row = attackCoordinates[0].row;
                int col = attackCoordinates[0].col;
                attackCoordinates.RemoveAt(0);
                if (IsInside(row, col, field) && field[row][col] == '<')
                {
                    field[row][col] = 'X';
                    info["firstPlayerShips"]--;
                    info["sunkShips"]++;
                }
                else if (IsInside(row, col, field) && field[row][col] == '>')
                {
                    field[row][col] = 'X';
                    info["secondPlayerShips"]--;
                    info["sunkShips"]++;
                }
                else if (IsInside(row, col, field) && field[row][col] == '#')
                {
                    field[row][col] = 'X';
                    Explode(row, col-1, field, info);
                    Explode(row, col+1, field, info);
                    Explode(row-1, col, field, info);
                    Explode(row-1, col-1, field, info);
                    Explode(row-1, col+1, field, info);
                    Explode(row+1, col, field, info);
                    Explode(row+1, col-1, field, info);
                    Explode(row+1, col+1, field, info);                    
                }

                if (info["firstPlayerShips"] <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {info.GetValueOrDefault("sunkShips")} ships have been sunk in the battle.");
                    return;
                }
                if (info["secondPlayerShips"] <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {info.GetValueOrDefault("sunkShips")} ships have been sunk in the battle.");
                    return;
                }
            }
            Console.WriteLine($"It's a draw! Player One has {info.GetValueOrDefault("firstPlayerShips")} ships left. Player Two has {info.GetValueOrDefault("secondPlayerShips")} ships left.");
        }

        private static void Explode(int row, int col, char[][] field, Dictionary<string, int> info)
        {
            if (IsInside(row, col, field))
            {
                if (field[row][col] == '<')
                {
                    field[row][col] = 'X';
                    info["firstPlayerShips"]--;
                    info["sunkShips"]++;
                }
                else if (field[row][col] == '>')
                {
                    field[row][col] = 'X';
                    info["secondPlayerShips"]--;
                    info["sunkShips"]++;
                }
            }
        }

        private static bool IsInside(int row, int col, char[][] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field[row].Length;
        }
    }
}
