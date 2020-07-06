using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodePractice.Problems.Problem51
{
    public class Solution
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            return Method1(n);
        }

        #region Method1(DFS)
        private IList<IList<string>> Method1(int n)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Method1_DFS(0, n, new List<int>(), new HashSet<int>(), new HashSet<int>(), result);
            return result;
        }

        private void Method1_DFS(int level, int n,
                        List<int> col, HashSet<int> sum, HashSet<int> dif,
                        IList<IList<string>> result)
        {
            //Terminator
            if (level == n)
            {
                result.Add(Method1_CreateResult(col));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!col.Contains(i) && !sum.Contains(level + i) && !dif.Contains(level - i))
                {
                    col.Add(i);
                    sum.Add(level + i);
                    dif.Add(level - i);

                    //dig
                    Method1_DFS(level + 1, n, col, sum, dif, result);

                    col.Remove(i);
                    sum.Remove(level + i);
                    dif.Remove(level - i);
                }
            }
        }

        private IList<string> Method1_CreateResult(List<int> col)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < col.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < col.Count; j++)
                {
                    if (col[i] == j)
                    {
                        sb.Append("Q");
                        continue;
                    }
                    sb.Append(".");
                }
                result.Add(sb.ToString());
            }
            return result;
        }
        #endregion

        #region Method2(DFS - Less Memory Usage)
        private IList<IList<string>> Method2(int n)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Method2_DFS(0, n, new bool[n], new bool[n * 2], new bool[n * 2], new List<string>(), result);
            return result;
        }

        private void Method2_DFS(int level, int n,
                        bool[] col, bool[] sum, bool[] dif,
                        IList<string> oneSolution,
                        IList<IList<string>> result)
        {
            //Terminator
            if (level == n)
            {

                result.Add(new List<string>(oneSolution));
                return;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                if (!col[i] && !sum[level + i] && !dif[level - i + n])
                {
                    col[i] = true;
                    sum[level + i] = true;
                    dif[level - i + n] = true;

                    //create result
                    for (int j = 0; j < n; j++)
                    {
                        sb.Append(j == i ? "Q" : ".");
                    }
                    oneSolution.Add(sb.ToString());

                    //dig
                    Method2_DFS(level + 1, n, col, sum, dif, oneSolution, result);

                    col[i] = false;
                    sum[level + i] = false;
                    dif[level - i + n] = false;
                    oneSolution.Remove(oneSolution.Last());
                    sb.Clear();
                }
            }
        }
        #endregion
    }
}
