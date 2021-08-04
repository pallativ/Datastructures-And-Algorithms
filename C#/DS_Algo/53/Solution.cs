using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures._53
{
    public class Solution
    {
        private int?[] memo;
        public int MaxSubArray(int[] nums)
        {
            memo = new int?[nums.Length + 1];
            //return Naive(nums);
            return DP(nums);
        }
        public int Naive(int[] nums)
        {
            int maxSum = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int currSum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    currSum += nums[j];
                    maxSum = Math.Max(currSum, maxSum);
                }
            }
            return maxSum;
        }
        public int DP(int[] nums)
        {
            int currentSubArraySum = 0;
            int maxSubAraySum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                currentSubArraySum = Math.Max(nums[i], currentSubArraySum + nums[i]);
                maxSubAraySum = Math.Max(maxSubAraySum, currentSubArraySum);
            }
            return maxSubAraySum;
        }
    }
}
