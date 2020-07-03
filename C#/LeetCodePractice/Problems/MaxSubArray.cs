public class Solution {
    public int MaxSubArray(int[] nums) {
        int sum, maxSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (sum < 0)
            {
                sum = 0;
            }
            sum += nums[i];

            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }
        return maxSum;
    }
}