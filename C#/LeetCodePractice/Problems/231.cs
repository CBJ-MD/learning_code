using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice.Problems.Problem231
{
    public class Solution
    {
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }
    }
}
