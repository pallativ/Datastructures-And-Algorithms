using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Datastructures.Tests._53
{
    public class Tests
    {
        [Fact]
        public void Test()
        {
            var solution = new Datastructures._53.Solution();
            var array = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var result = solution.MaxSubArray(array);
            Assert.Equal(6, result);
        }
    }
}
