using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class BestTimeToBuyAndSellStock
    {
        private Dictionary<int, int> memo = new Dictionary<int, int>();
        public int MaxProfit(int[] prices)
        {
            return MaxProfitBruteForace(prices, 0);
        }
        public int MaxProfitBruteForace(int[] prices, int start)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            if (memo.ContainsKey(start))
                return memo[start];
            for (int i = start; i < prices.Length; i++)
            {
                if (prices[i] <= minPrice)
                    minPrice = prices[i];
                else
                {
                    var currentProfit = (prices[i] - minPrice) + MaxProfitBruteForace(prices, i + 1);
                    maxProfit = Math.Max(maxProfit, currentProfit);
                }
            }
            memo.Add(start, maxProfit);
            return maxProfit;
        }
        [Fact]
        public void Test()
        {
            var result = MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
        }

    }
}
