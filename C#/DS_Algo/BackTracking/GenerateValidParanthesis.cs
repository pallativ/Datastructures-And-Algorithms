using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Datastructures.BackTracking
{
    public class GenerateValidParanthesis
    {
        private int max = 0;
        private List<string> validParathesisList = new List<string>();

        private readonly ITestOutputHelper output;

        public GenerateValidParanthesis(ITestOutputHelper output)
        {
            this.output = output;
        }


        public List<string> Generate(int n)
        {
            max = n;
            StringBuilder current = new StringBuilder();
            BackTrack(current, 0, 0);
            return validParathesisList;
        }

        private void BackTrack(StringBuilder currentParanthesis, int open, int close)
        {
            
            if (currentParanthesis.Length == max * 2)
            {
                validParathesisList.Add(currentParanthesis.ToString());
                output.WriteLine("*****");
                return;
            }
           
            if (open < max)
            {
                currentParanthesis.Append("(");
                output.WriteLine($"({open}, {close}) => {currentParanthesis.ToString()}");
                BackTrack(currentParanthesis, open + 1, close);
                currentParanthesis.Remove(currentParanthesis.Length - 1, 1);
            }

            if (close < open)
            {
                currentParanthesis.Append(")");
                output.WriteLine($"({open}, {close}) => {currentParanthesis.ToString()}");
                BackTrack(currentParanthesis, open, close + 1);
                currentParanthesis.Remove(currentParanthesis.Length - 1, 1);
            }
        }

        [Theory]
        [ClassData(typeof(GenerateData))]
        public void Test(Input input)
        {
            var actual = Generate(input.Max);
            input.Result.Sort();
            actual.Sort();
            Assert.Equal(input.Result, actual);
        }
    }
    public class Input
    {
        public int Max { get; set; }
        public List<string> Result { get; set; }
    }
    public class GenerateData : IEnumerable<Object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Input()
                {
                    Max = 3,
                    Result = new List<string>(){ "((()))", "(()())", "(())()", "()(())", "()()()" }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
