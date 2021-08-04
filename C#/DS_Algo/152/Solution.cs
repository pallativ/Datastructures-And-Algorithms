using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures._152
{
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            int maxProduct = 0;
            int current_max = nums[0], current_min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                var temp_max = Math.Max(nums[i], Math.Max(current_max * nums[i], current_min * nums[i]));
                current_min = Math.Min(nums[i], Math.Min(current_max * nums[i], current_min * nums[i]));
                current_max = temp_max;
                maxProduct = Math.Max(maxProduct, temp_max);
            }
            return maxProduct;
        }
    }
}
