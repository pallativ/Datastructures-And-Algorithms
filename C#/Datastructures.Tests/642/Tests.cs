using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Datastructures.Tests._642
{
    public class Tests
    {
        [Fact]
        public void Test()
        {
            var sentances = new String[] { "i love you", "island", "iroman", "i love leetcode" };
            var times = new int[] { 5, 3, 2, 2 };
            var solution = new Datastructures._642.AutocompleteSystem(sentances, times);
        }
    }
}
