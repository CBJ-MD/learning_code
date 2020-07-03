using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Debug.Assert(false, "what the hell!");
        }

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
