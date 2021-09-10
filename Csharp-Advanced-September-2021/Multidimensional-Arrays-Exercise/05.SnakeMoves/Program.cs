using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] sizes = ReadArrayFromConsole();

            string snake = Console.ReadLine();

            string[][] snakePath = new string[sizes[0]][];

            string temp = snake;

            for (int i = 0; i < snakePath.GetLength(0); i++)
            {
                snakePath[i] = new string[sizes[1]];

                if (i % 2 == 0)
                {
                    for (int j = 0; j < sizes[1]; j++)
                    {
                        if (snake.Length == 0)
                        {
                            snake += temp;
                        }
                        snakePath[i][j] = snake[0].ToString();
                        snake = snake.Remove(0, 1);

                    }
                }
                else
                {
                    for (int j = sizes[1] - 1; j >= 0; j--)
                    {
                        if (snake.Length == 0)
                        {
                            snake += temp;
                        }
                        snakePath[i][j] = snake[0].ToString();
                        snake = snake.Remove(0, 1);

                    }
                }
               
            }

            foreach (var item in snakePath)
            {
                Console.WriteLine(String.Join("", item));
            }
        }
        private static byte[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(byte.Parse)
                .ToArray();
        }
    }
}
