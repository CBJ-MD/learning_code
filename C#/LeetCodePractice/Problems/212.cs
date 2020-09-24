using LeetCodePractice.Problems.Problem208;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice.Problems.Problem212
{
    public class Solution
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            return TrieApproach(board, words);
        }

        #region TrieApproach
        private IList<string> TrieApproach(char[][] board, string[] words)
        {
            if (words == null || words.Length == 0 ||
                board == null || board.Length == 0)
            {
                return new List<string> ();
            }

            Trie trie = new Trie();
            
            for (int i = 0; i < words.Length; i++)
            {
                trie.Insert(words[i]);
            }

            HashSet<string> res = new HashSet<string>();
            int xMax = board.Length;
            int yMax = board[0].Length;
            for (int i = 0; i < xMax; i++)
            {
                for (int j = 0; j < yMax; j++)
                {
                    DFS(trie, i, j, board, new bool[xMax, yMax], "", res);
                }
            }
            return new List<string>(res);
        }

        private void DFS(Trie trie, int i, int j, char[][] board, bool[,] visited, string str, HashSet<string> res)
        {
            if (i >= board.Length || j >= board[0].Length ||
                i < 0 || j < 0 || visited[i,j])
            {
                return;
            }

            str += board[i][j];
            if (!trie.StartsWith(str))
            {
                return;
            }

            if (trie.Search(str))
            {
                res.Add(str);
            }

            visited[i, j] = true;
            DFS(trie, i + 1, j, board, visited, str, res);
            DFS(trie, i - 1, j, board, visited, str, res);
            DFS(trie, i, j + 1, board, visited, str, res);
            DFS(trie, i, j - 1, board, visited, str, res);
            visited[i, j] = false;
        }
        #endregion
    }
}
