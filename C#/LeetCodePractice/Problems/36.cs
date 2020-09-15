using System;
using System.Net.Http.Headers;
using System.Security.Principal;

namespace LeetCodePractice.Problems.Problem36
{
    public class Solution
    {
        const int _BLANK = 46;

        public bool IsValidSudoku(char[][] board)
        {
            return Method1(board);
        }

        public char[,] SolveSudoku(char[,] board)
        {
            bool result = false;
            Method1_DFS(0, board, ref result);
            return board;
        }

        #region Method1 DFS(Naive)
        private bool Method1(char[][] board)
        {
            bool result = false;
            //Method1_DFS(0, board, ref result);
            return result;
        }

        private static int total = 0;

        private void Method1_DFS(int depth, char[,] board, ref bool result)
        {
            if (depth == board.Length)
            {
                result = true;
                return;
            }

            int column = depth % 9;
            int row = depth / 9;

            Console.WriteLine($"processing: total: {total++}, depth:{depth}, column: {column}, row: {row}");

            if (board[column, row] == _BLANK)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (Method1_IsValid(column, row, i, board))
                    {
                        board[column, row] = (char)i;
                        Method1_DFS(depth + 1, board, ref result);
                        board[column, row] = (char)_BLANK;
                    }
                }
                return;
            }
            else
            {
                Method1_DFS(depth + 1, board, ref result);
            }
        }

        private bool Method1_IsValid(int column, int row, int num, char[,] board)
        {
            int cellColumn = column / 3;
            int cellRow = row / 3;
            for (int i = 0; i < 9; i++)
            {
                if (board[column, i] == num ||
                    board[i, row] == num ||
                    board[i % 3 + cellColumn * 3, i / 3 + cellRow * 3] == num)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
