using System;
using System.Data;
using System.Net.Http.Headers;
using System.Security.Principal;

namespace LeetCodePractice.Problems.Problem36
{
    public class Solution
    {
        const int _BLANK = '.';
        const int _Zero = '0';

        public bool IsValidSudoku(char[][] board)
        {
            return Method1(board);
        }

        #region Method1 DFS(Naive)
        private bool Method1(char[][] board)
        {
            return Method1_DFS(board, 0, 0);
        }

        private bool Method1_DFS(char[][] board, int col, int row)
        {
            if (row == board.Length - 1 && col == board.Length)
            {
                return true;
            }

            if (col == board.Length)
            {
                col = 0;
                row++;
            }

            if (board[col][row] == _BLANK)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (Method1_IsValid(col, row, i + _Zero, board))
                    {
                        board[col][row] = (char)(i + _Zero);
                        if (Method1_DFS(board, col + 1, row)) return true;
                        board[col][row] = (char)_BLANK;
                    }
                }
                return false;
            }
            return Method1_DFS(board, ++col, row);
        }

        private bool Method1_IsValid(int col, int row, int num, char[][] board)
        {
            int cellColumn = col / 3;
            int cellRow = row / 3;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[col][i] == num ||
                    board[i][row] == num ||
                    board[i % 3 + cellColumn * 3][i / 3 + cellRow * 3] == num)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
