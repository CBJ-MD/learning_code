using System;
using System.Text;

namespace LeetCodePractice.Problems.Problem10
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            int lenS = s.Length;
            int lenP = p.Length;
            bool[,] res = new bool[lenP + 1, lenS + 1];
            res[0, 0] = true;

            for (int i = 0; i < lenP; i++)
            {
                if (p[i] == '*')
                {
                    res[i + 1, 0] = res[i - 1, 0];
                }
            }

            for (int i = 1; i <= lenP; i++)
            {
                for (int j = 1; j <= lenS; j++)
                {
                    if (p[i - 1] == '*')
                    {
                        if (IsMatch(s, p, i - 2, j - 1))
                        {
                            res[i, j] = res[i, j - 1] || res[i - 1, j - 1] || res[i - 2, j];
                        }
                        else
                        {
                            res[i, j] = res[i - 2, j];
                        }
                    }
                    else
                    {
                        res[i, j] = res[i - 1, j - 1] && IsMatch(s, p, i - 1, j - 1);
                    }
                }
            }
            return res[lenP, lenS];
        }

        private static bool IsMatch(string s, string p, int indexP, int indexS)
        {
            if (indexP < 0) return false;
            if (p[indexP] == '.') return true;
            return s[indexS] == p[indexP];
        }

        /// <summary>
        /// for debugging
        /// </summary>
        /// <param name="mat"></param>
        private static void PrintMat(bool[,] mat)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j <= mat.GetUpperBound(0); j++)
            {
                for (int k = 0; k <= mat.GetUpperBound(1); k++)
                {
                    sb.Append(mat[j, k] + ",");
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
