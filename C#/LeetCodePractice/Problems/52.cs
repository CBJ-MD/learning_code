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

        #region Method2(DFS + bitwise operation)

        private int Method2(int n)
        {
            var result = 0;
            Method2_DFS(n, 0, 0, 0, 0, ref result);
            return result;
        }

        private void Method2_DFS(int n, int level, int col, int downLeft, int downRight, ref int result)
        {
            if (level >= n)
            {
                result++;
                return;
            }

            int availableBits = ~(col | downLeft | downRight) & (1<<n)-1;// <= 去除除了N位之外的所有位
            while (availableBits > 0)
            {
                // “-” 取反加1，下式取出了availableBits的最后一个“1”
                int bit = availableBits & (-availableBits);
                Method2_DFS(n, level + 1, col | bit, (downLeft | bit) << 1, (downRight | bit) >> 1, ref result);
                availableBits &= (availableBits - 1);
            }
        }
        #endregion
    }
}
