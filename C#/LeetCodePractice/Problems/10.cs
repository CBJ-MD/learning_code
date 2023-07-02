using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for (int i = 1; i <= lenP; i++)
            {
                for (int j = 1; j <= lenS; j++)
                {
                    if (p[i - 1] == '*')
                    {
                        if (IsMatch(s, p, i - 1, j))
                        {
                            res[i, j] = res[i, j - 1] || res[i - 1, j - 1];
                        }
                        else
                        {
                            res[i, j] = res[i - 2, j - 1];
                        }
                    }
                    else
                    {
                        res[i, j] = res[i - 1, j - 1] & IsMatch(s, p, i, j);
                    }
                }
            }
            Console.WriteLine(res[lenP, lenS]);
            return res[lenP, lenS];
        }

        private static bool IsMatch(string s, string p, int indexP, int indexS)
        {
            indexS--;
            indexP--;
            if (indexP < 0) return false;
            if (p[indexP] == '.') return true;
            return s[indexS] == p[indexP];
        }
    }
}
