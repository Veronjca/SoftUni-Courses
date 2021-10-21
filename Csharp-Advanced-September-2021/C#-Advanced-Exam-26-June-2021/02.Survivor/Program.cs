using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            byte rows = byte.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                beach[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }
           
            string command;
            int myTokens = 0;
            int opponentTokens = 0;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Find")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);
                    if (IsInside(row, col, beach))
                    {
                        if (beach[row][col] == 'T')
                        {
                            myTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if (commandArgs[0] == "Opponent")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);
                    string direction = commandArgs[3];
                    if (IsInside(row, col, beach))
                    {
                        if (beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }
                        if (direction == "up")
                        {                       
                            for (int i = row-1; i >= row-3; i--)
                            {
                                if (IsInside(i, col, beach))
                                {
                                    if (beach[i][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[i][col] = '-';
                                    }
                                }                                                            
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = row + 1; i <= row + 3; i++)
                            {
                                if (IsInside(i, col, beach))
                                {
                                    if (beach[i][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[i][col] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = col + 1; i <= col + 3; i++)
                            {
                                if (IsInside(row, i, beach))
                                {
                                    if (beach[row][i] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[row][i] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = col - 1; i >= col - 3; i--)
                            {
                                if (IsInside(row, i, beach))
                                {
                                    if (beach[row][i] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[row][i] = '-';
                                    }
                                }
                            }
                        }
                    }               
                }
            }

            foreach (var item in beach)
            {
                Console.WriteLine(String.Join(' ', item));
            }
            Console.WriteLine($"Collected tokens: {myTokens}{Environment.NewLine}Opponent's tokens: {opponentTokens}");
        }

        private static bool IsInside(int row, int col, char[][] beach)
        {
            return row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].Length;
        }
    }
}
