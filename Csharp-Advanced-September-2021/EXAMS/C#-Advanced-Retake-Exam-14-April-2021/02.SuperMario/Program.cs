using System;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] maze = new char[n][];

            for (int i = 0; i < n; i++)
            {
                maze[i] = Console.ReadLine().ToCharArray();
            }

            (int row, int col) coordinates = GetMarioCoordinates(maze);
            maze[coordinates.row][coordinates.col] = '-';
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];
                int enemyRow = int.Parse(input[1]);
                int enemyCol = int.Parse(input[2]);
                maze[enemyRow][enemyCol] = 'B';
                lives--;
                if (direction == "W")
                {
                    coordinates.row--;
                    if (coordinates.row < 0)
                    {
                        coordinates.row = 0;
                    }
                    lives = FightBowser(lives, maze, coordinates);
                }
                else if (direction == "S")
                {
                    coordinates.row++;
                    if (coordinates.row >= n)
                    {
                        coordinates.row = n - 1;
                    }
                    lives = FightBowser(lives, maze, coordinates);
                }
                else if (direction == "A")
                {
                    coordinates.col--;
                    if (coordinates.col < 0)
                    {
                        coordinates.col = 0;
                    }
                    lives = FightBowser(lives, maze, coordinates);                    
                }
                else if (direction == "D")
                {
                    coordinates.col++;
                    if (coordinates.col >= maze[coordinates.row].Length)
                    {
                        coordinates.col = maze[coordinates.row].Length - 1;
                    }
                    lives = FightBowser(lives, maze, coordinates);
                }
                if (maze[coordinates.row][coordinates.col] == 'P')
                {
                    maze[coordinates.row][coordinates.col] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    PrintMatrix(maze);
                    Environment.Exit(0);
                }
                if (IsDead(lives, maze, coordinates))
                {
                    break;
                }
            }
            Console.WriteLine($"Mario died at {coordinates.row};{coordinates.col}.");
            PrintMatrix(maze);
        }

        private static void PrintMatrix(char[][] maze)
        {
            foreach (var item in maze)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static int FightBowser(int lives, char[][] maze, (int row, int col) coordinates)
        {
            if (maze[coordinates.row][coordinates.col] == 'B')
            {
                lives -= 2;
                maze[coordinates.row][coordinates.col] = '-';
            }
            return lives;
        }

        private static bool IsDead(int lives, char[][] maze, (int row, int col) coordinates)
        {
            if (lives <= 0)
            {
                maze[coordinates.row][coordinates.col] = 'X';
                return true;
            }
            return false;
        }

        private static (int row, int col) GetMarioCoordinates(char[][] maze)
        {
            int row = 0;
            int col = 0;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (maze[i][j] == 'M')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return (row, col);
        }
    }
}
