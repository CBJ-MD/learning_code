using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCodePractice.Problems.Problem69
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            return Method1(x);
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private int Method1(int y)
        {
            if (y == 0 || y == 1)
            {
                return y;
            }

            int l = 0;
            int u = y;
            while (l <= u)
            {
                int mid = (l + u) / 2;
                if (y / mid == mid)
                {
                    return mid;
                }

                if (y / mid < mid) // mid * mid会导致int溢出
                {
                    u = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return u;
        }

        /// <summary>
        /// 牛顿迭代
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private int Method2(int y)
        {
            if (y == 0 || y == 1)
            {
                return y;
            }

            double x = y; // 单精度无法通过2147395599
            while (x > y / x)
            {
                x = x / 2 + y / (2 * x);
                x = (int)x; // 向下圆整
            }
            return (int)x;
        }
    }
}
