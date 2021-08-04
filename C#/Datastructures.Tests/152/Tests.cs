using Xunit;

namespace Datastructures.Tests._152
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            int[] input = new int[] { 2, 3, -2, 4 };
            Datastructures._152.Solution solution = new Datastructures._152.Solution();
            var result = solution.MaxProduct(input);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            int[] input = new int[] { -2, 0, -1 };
            Datastructures._152.Solution solution = new Datastructures._152.Solution();
            var result = solution.MaxProduct(input);
            Assert.Equal(0, result);
        }
    }
}
