using System;

namespace LeetCodePractice.Problems.Problem1991
{
    public class Solution
    {
        public int FindMiddleIndex(int[] nums)
        {
            int sum = 0;
            int left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0)
                    left += nums[i - 1];
                sum -= nums[i];
                if (left == sum)
                    return i;
            }

            return -1;
        }

        public int SearchInsert(int[] nums, int target)
        {
            return BinarySearch(nums, nums.Length, 0, target);
        }

        private int BinarySearch(int[] nums, int high, int low, int target)
        {
            int mid = (high + low) / 2;
            if (mid == low)
                return target > nums[mid] ? ++mid : mid;
            if (nums[mid] == target)
                return mid;

            if (nums[mid] > target)
            {
                return BinarySearch(nums, mid, low, target);
            }
            else
            {
                return BinarySearch(nums, high, mid, target);
            }
        }
    }
}
