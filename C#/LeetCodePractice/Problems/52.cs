namespace LeetCodePractice.Problems.Problem52
{
    public class Solution
    {
        public int TotalNQueens(int n)
        {
            return Method1(n);
        }

        #region Method1(DFS)
        private int Method1(int n)
        {
            int count = 0;
            Method1_DFS(0, n, new bool[n], new bool[n * 2], new bool[n * 2], ref count);
            return count;
        }

        private void Method1_DFS(int level, int n,
                        bool[] col, bool[] sum, bool[] dif,
                        ref int count)
        {
            //Terminator
            if (level == n)
            {
                count++;
                return;
            }

            for (int i = 0; i < n; i++)
            {
                int idSum = level + i;
                int idDiff = level - i + n;

                if (!col[i] && !sum[idSum] && !dif[idDiff])
                {
                    col[i] = true;
                    sum[idSum] = true;
                    dif[idDiff] = true;

                    //dig
                    Method1_DFS(level + 1, n, col, sum, dif, ref count);

                    col[i] = false;
                    sum[idSum] = false;
                    dif[idDiff] = false;
                }
            }
        }
        #endregion
    }
}
