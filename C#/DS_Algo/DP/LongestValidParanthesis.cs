using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class LongestValidParanthesis
    {
        private bool?[,] memo;
        public int LongestValidParentheses(string str)
        {
            //memo = new bool?[str.Length + 1, str.Length + 1];
            return Version2(str);
        }

        public int Version2(string s)
        {
            var stack = new Stack<int>();
            int maxLength = 0;
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                        stack.Push(i);
                    else
                        maxLength = Math.Max(maxLength, i - stack.Peek());
                }
            }
            return maxLength;
        }
        public int Version1(string s, int start, int end)
        {
            if (start >= end)
                return 0;
            if (memo[start, end].HasValue)
                return memo[start, end].Value ? end - start : 0;

            Stack<char> stack = new Stack<char>();
            for (int i = start; i < end; i++)
            {
                if (stack.Count > 0 && stack.Peek() == '(' && s[i] == ')')
                    stack.Pop();
                else
                    stack.Push(s[i]);
            }
            if (stack.Count == 0)
            {
                memo[start, end] = true;
                return end - start;
            }
            else
            {
                memo[start, end] = false;
                var result = Math.Max(Version1(s, start + 1, end),
                    Version1(s, start, end - 1));
                return result;
            }
        }
        [Theory]
        [ClassData(typeof(GenerateLongestValidParanthesisInput))]
        public void Test(LongestValidParanthesisInput input)
        {
            var result = LongestValidParentheses(input.Input);
            Assert.Equal(input.Result, result);
        }
    }

    public class LongestValidParanthesisInput
    {
        public string Input { get; set; }
        public int Result { get; set; }
    }
    public class GenerateLongestValidParanthesisInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new LongestValidParanthesisInput()
                    {
                       Input = "(()",
                       Result = 2,
                    }
            };
            yield return new object[]
            {
                    new LongestValidParanthesisInput()
                    {
                       Input = ")()())",
                       Result = 4,
                    }
            };
            yield return new object[]
          {
                    new LongestValidParanthesisInput()
                    {
                       Input = "",
                       Result = 0,
                    }
          };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
