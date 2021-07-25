using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class _0_By_1_KnapsackProblem
    {
        public int SolveKnapsack(int[] profits, int[] weights, int capacity)
        {
            return SolveKnapsack(profits, weights, capacity, 0);
        }
        private int SolveKnapsack(int[] profits, int[] weights, int capacity, int currentIndex)
        {
            if (currentIndex >= weights.Length)
                return 0;
            if (capacity <= 0) return 0;

            int profitInclusive = 0, profitExclusive = 0;
            if (capacity >= weights[currentIndex])
                profitInclusive = profits[currentIndex] + SolveKnapsack(profits, weights, capacity - weights[currentIndex], currentIndex + 1);

            profitExclusive = SolveKnapsack(profits, weights, capacity, currentIndex + 1);
            return Math.Max(profitExclusive, profitInclusive);
        }

        [Theory]
        [ClassData(typeof(GenerateData))]
        public void Test(Knapsack knapsack)
        {
            var actual = SolveKnapsack(knapsack.Profits, knapsack.Weights, knapsack.Capacity);
            Assert.Equal(knapsack.Result, actual);
        }


        public class Knapsack
        {
            public int[] Profits { get; set; }
            public int[] Weights { get; set; }
            public int Capacity { get; set; }
            public int Result { get; set; }
        }

        public class GenerateData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new Knapsack()
                    {
                        Profits = new int[]{1, 6, 10, 16},
                        Weights = new int[] {1, 2, 3, 5},
                        Capacity = 7,
                        Result = 22
                    }
                };
                yield return new object[]
                {
                     new Knapsack()
                    {
                        Profits = new int[] { 1, 6, 10, 16 },
                        Weights = new int[] { 1, 2, 3, 5 },
                        Capacity = 6,
                        Result = 17
                    }
                };

            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
