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
            return MaxProfitIII(prices, 0, 2);
            //return MaxProfitBruteForace(prices, 0);
        }
        public int OnePassSolution(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }

        public int MaxProfitIII(int[] prices, int start, int remaining)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            if (remaining == 0)
                return 0;
            //if (memo.ContainsKey(start))
            //    return memo[start];
            for (int i = start; i < prices.Length; i++)
            {
                if (prices[i] <= minPrice)
                    minPrice = prices[i];
                else
                {
                    var currentProfit = (prices[i] - minPrice) + MaxProfitIII(prices, i + 1, remaining - 1);
                    maxProfit = Math.Max(maxProfit, currentProfit);
                }
            }
            //memo.Add(start, maxProfit);
            return maxProfit;
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
            //var result = MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
            var result = MaxProfit(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 });
        }

    }
}
