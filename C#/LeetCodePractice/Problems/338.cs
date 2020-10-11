using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice.Problems.Problem338
{
    public class Solution
    {
        public int[] CountBits(int num)
        {
            return Dummy(num);
        }

        /// <summary>
        /// 204 ms	29.6 MB
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int[] Dummy(int num)
        {
            int[] res = new int[num + 1];
            for (int i = 0; i < res.Length; i++)
            {
                int count = 0;
                int current = i;
                while (current != 0)
                {
                    current &= current - 1;
                    count++;
                }
                res[i] = count;
            }
            return res;
        }

        /// <summary>
        /// 212 ms	29.8 MB
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int[] Advanced(int num)
        {
            int[] res = new int[num + 1];
            for (int i = 1; i < res.Length; i++)
            {
                res[i] = res[i & (i - 1)] + 1;
            }
            return res;
        }
    }
}
