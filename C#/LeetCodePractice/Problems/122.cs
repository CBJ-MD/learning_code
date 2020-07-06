namespace LeetCodePractice.Problems.Problem122
{
    class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                int diff = prices[i + 1] - prices[i];
                if (diff > 0)
                {
                    profit += diff;
                }
            }
            return profit;
        }
    }
}

