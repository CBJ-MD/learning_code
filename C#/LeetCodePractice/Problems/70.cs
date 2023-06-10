using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice.Problems.Problem70
{
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            return RecursiveApproach(n);
        }

        private int RecursiveApproach(int n) // Time Limit Exceeded
        {
            if (n < 2)
            {
                return 1;
            }
            return RecursiveApproach(n - 1) + RecursiveApproach(n - 2);
        }

        private int DPApproach(int n)
        {
            int OneStepBefore = 1;
            int TwoStepBefore = 0;

            for (int i = 1; i < n; i++)
            {
                int temp = TwoStepBefore;
                TwoStepBefore = OneStepBefore;
                OneStepBefore = OneStepBefore + temp;
            }
            return OneStepBefore + TwoStepBefore;
        }
    }
}
