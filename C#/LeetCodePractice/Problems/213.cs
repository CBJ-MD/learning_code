using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCodePractice.Problems.Problem213
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            int len = nums.Length;
            if (len == 0) return 0;
            if (len == 1) return nums[0];
            if (len == 2) return Math.Max(nums[0], nums[1]);
            return Math.Max(Sum(nums, 0, len - 2), Sum(nums, 1, len - 1));
        }

        private int Sum(int[] nums, int startIndex, int endIndex)
        {
            int[] dp = new int[nums.Length];
            dp[startIndex] = nums[startIndex];
            dp[startIndex + 1] = Math.Max(nums[startIndex], nums[startIndex + 1]);

            for (int i = startIndex + 2; i <= endIndex; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return Math.Max(dp[endIndex], dp[endIndex - 1]);
        }
    }
}
