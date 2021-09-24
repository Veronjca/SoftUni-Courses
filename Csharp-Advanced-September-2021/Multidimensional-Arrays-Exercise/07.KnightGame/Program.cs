using System;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] board = new char[size][];

            for (int i = 0; i < size; i++)
            {
                board[i] = new char[size];
                board[i] = Console.ReadLine().ToCharArray();
            }

            int maxKnights = 0;
            
            while (true)
            {
                int maxAttacked = 0;
                int row = 0;
                int col = 0;

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        if (board[i][j] == 'K')
                        {
                            int counter = 0;

                            if (IsInside(board, i - 2, j - 1) && board[i - 2][j - 1] == 'K')
                            {
                                counter++;
                            }
                            if (IsInside(board, i - 1, j - 2) && board[i - 1][j - 2] == 'K')
                            {
                                counter++;
                            }
                            if (IsInside(board, i - 2, j + 1) && board[i - 2][j + 1] == 'K')
                            {
                                counter++;
                            }
                            if (IsInside(board, i - 1, j + 2) && board[i - 1][j + 2] == 'K')
                            {
                                counter++;
                            }
                            if (IsInside(board, i + 1, j - 2) && board[i + 1][j - 2] == 'K')
                            {
                                counter++;
                            }
                            if (IsInside(board, i + 2, j - 1) && board[i + 2][j - 1] == 'K')
                            {
                                counter++;
                            }
                            if (IsInside(board, i + 1, j + 2) && board[i + 1][j + 2] == 'K')
                            {
                                counter++;
                            }
                            if (IsInside(board, i + 2, j + 1) && board[i + 2][j + 1] == 'K')
                            {
                                counter++;
                            }

                            if (counter > maxAttacked)
                            {
                                maxAttacked = counter;
                                row = i;
                                col = j;
                            }
                        }
                    }
                }

                if (maxAttacked != 0)
                {
                    board[row][col] = '0';
                    maxKnights++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(maxKnights);
        }

        public static bool IsInside(char[][] board, int firstIndex, int secondIndex)
        {
            if (firstIndex >= 0 && firstIndex < board.GetLength(0) && secondIndex >= 0 && secondIndex < board[firstIndex].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}