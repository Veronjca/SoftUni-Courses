using System;

namespace _02.PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[8][];
            for (int i = 0; i < 8; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }

            (int row, int col) whitePawn = GetPosition('w', board);
            (int row, int col) blackPawn = GetPosition('b', board);
            int counter = 0;

            string[,] chessBoard = new string[8, 8];
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    chessBoard[i, j] = $"{(char)('a' + j)}{8 - i}";
                }
            }
            bool isWinner = false;


            while (true)
            {
                if (counter % 2 == 0)
                {
                    if (IsInside(whitePawn.row - 1, whitePawn.col, board))
                    {
                        if (IsInside(whitePawn.row - 1, whitePawn.col - 1, board) && board[whitePawn.row - 1][whitePawn.col - 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {chessBoard[whitePawn.row - 1, whitePawn.col - 1]}.");
                            return;
                        }
                        else if (IsInside(whitePawn.row - 1, whitePawn.col + 1, board) && board[whitePawn.row - 1][whitePawn.col + 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {chessBoard[whitePawn.row - 1, whitePawn.col + 1]}.");
                            return;
                        }
                        else
                        {
                            board[whitePawn.row][whitePawn.col] = '-';
                            whitePawn.row -= 1;
                            if (!IsInside(whitePawn.row - 1, whitePawn.col, board))
                            {
                                Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessBoard[whitePawn.row, whitePawn.col]}.");
                                return;
                            }
                        }

                    }
                }
                else
                {
                    if (IsInside(blackPawn.row + 1, blackPawn.col, board))
                    {
                        if (IsInside(blackPawn.row + 1, blackPawn.col - 1, board) && board[blackPawn.row - 1][blackPawn.col - 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {chessBoard[blackPawn.row + 1, blackPawn.col - 1]}.");
                            return;
                        }
                        else if (IsInside(blackPawn.row + 1,blackPawn.col + 1, board) && board[blackPawn.row - 1][blackPawn.col + 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {chessBoard[blackPawn.row + 1, blackPawn.col + 1]}.");
                            return;
                        }
                        else
                        {
                            board[blackPawn.row][blackPawn.col] = '-';
                            blackPawn.row += 1;
                            if (!IsInside(blackPawn.row + 1, blackPawn.col, board))
                            {
                                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessBoard[blackPawn.row, blackPawn.col]}.");
                                return;
                            }
                        }

                    }
                }
                counter++;

            }

        }

        private static bool IsInside(int row, int col, char[][] board)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board[row].Length;
        }

        private static (int row, int col) GetPosition(char letter, char[][] board)
        {
            (int row, int col) coordinates = (0, 0);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == letter)
                    {
                        coordinates = (i, j);
                    }
                }
            }
            return coordinates;
        }
    }
}
