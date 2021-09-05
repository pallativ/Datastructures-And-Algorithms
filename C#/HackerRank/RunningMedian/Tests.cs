using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.RunningMedian
{
    public class Tests
    {
        [Fact]
        public void Test()
        {
            var solution = new Solution();
            solution.RunningMedian(new int[] { 12, 4, 5, 3, 8, 7 });
        }
    }
}
