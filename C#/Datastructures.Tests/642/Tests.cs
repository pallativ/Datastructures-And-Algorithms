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
            var list = solution.input('i');
            var expected = new string[] { "i love you", "island", "i love leetcode" };
            Assert.Equal(expected, list);

            list = solution.input(' ');
            expected = new string[] { "i love you", "i love leetcode" };
            Assert.Equal(expected, list);

            list = solution.input('a');
            expected = new string[] {  };
            Assert.Equal(expected, list);

            list = solution.input('#');
            expected = new string[] { };
            Assert.Equal(expected, list);
        }


        [Fact]
        public void Test1()
        {
            var sentances = new string[] { "i love you", "island", "iroman", "i love leetcode" };
            var times = new int[] { 5, 3, 2, 2 };
            var solution = new Datastructures._642.AutocompleteSystem(sentances, times);
            var list = solution.input('i');
            var expected = new string[] { "i love you", "island", "i love leetcode" };
            Assert.Equal(expected, list);

            list = solution.input(' ');
            expected = new string[] { "i love you", "i love leetcode" };
            Assert.Equal(expected, list);

            list = solution.input('a');
            expected = new string[] { };
            Assert.Equal(expected, list);

            list = solution.input('#');
            expected = new string[] { };
            Assert.Equal(expected, list);


            list = solution.input('i');
            expected = new string[] { "i love you", "island", "i love leetcode" };
            Assert.Equal(expected, list);

            list = solution.input(' ');
            expected = new string[] { "i love you", "i love leetcode", "i a" };
            Assert.Equal(expected, list);

            list = solution.input('a');
            expected = new string[] { "i a" };
            Assert.Equal(expected, list);

            list = solution.input('#');
            expected = new string[] { };
            Assert.Equal(expected, list);


            list = solution.input('i');
            expected = new string[] { "i love you", "island", "i a" };
            Assert.Equal(expected, list);

            list = solution.input(' ');
            expected = new string[] { "i love you", "i a", "i love leetcode" };
            Assert.Equal(expected, list);

            list = solution.input('a');
            expected = new string[] { "i a" };
            Assert.Equal(expected, list);

            list = solution.input('#');
            expected = new string[] { };
            Assert.Equal(expected, list);
        }
    }
}
