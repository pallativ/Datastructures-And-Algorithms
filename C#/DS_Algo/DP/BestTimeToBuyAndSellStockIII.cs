using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class BestTimeToBuyAndSellStockIII
    {
        public int MaxProfit(int[] prices)
        {
            int?[][] memo = new int?[prices.Length][];
            return MaxProfitIII(prices, 0, 2, memo);
        }
        public int MaxProfitIII(int[] prices, int start, int remaining, int?[][] memo)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            if (remaining == 0)
                return 0;
            if (memo[start][remaining].HasValue)
                return memo[start][remaining].Value;
            for (int i = start; i < prices.Length; i++)
            {
                if (prices[i] <= minPrice)
                    minPrice = prices[i];
                else
                {
                    var currentProfit = (prices[i] - minPrice) + MaxProfitIII(prices, i + 1, remaining - 1, memo);
                    maxProfit = Math.Max(maxProfit, currentProfit);
                }
            }
            memo[start][remaining] = maxProfit;
            return maxProfit;
        }

        [Fact]
        public void Test()
        {
            //var result = MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
            var result = MaxProfit(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 });
        }

    }
}
