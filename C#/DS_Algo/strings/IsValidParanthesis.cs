using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.strings
{
    public class IsValidParanthesis
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count > 0 && ((stack.Peek() == '(' && s[i] == ')') ||
                                        (stack.Peek() == '{' && s[i] == '}') ||
                                        (stack.Peek() == '[' && s[i] == ']')))
                    stack.Pop();
                else
                    stack.Push(s[i]);
            }
            return stack.Count == 0;
        }
        [Theory]
        [ClassData(typeof(GenerateIsValidParanthesisInput))]
        public void Test(IsValidParanthesisInput input)
        {
            var actual = IsValid(input.Input);
            Assert.Equal(input.Result, actual);
        }
    }
    public class IsValidParanthesisInput
    {
        public string Input { get; set; }
        public bool Result { get; set; }
    }
    public class GenerateIsValidParanthesisInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new IsValidParanthesisInput()
                    {
                       Input = "(()",
                       Result = false,
                    }
            };
            yield return new object[]
            {
                    new IsValidParanthesisInput()
                    {
                       Input = "(())",
                       Result = true,
                    }
            };
            yield return new object[]
          {
                    new IsValidParanthesisInput()
                    {
                       Input = "()[]{}",
                       Result = true,
                    }
          };
            yield return new object[]
          {
                    new IsValidParanthesisInput()
                    {
                       Input = "(]",
                       Result = false,
                    }
          };
            yield return new object[]
        {
                    new IsValidParanthesisInput()
                    {
                       Input = "([)]",
                       Result = false,
                    }
        };
            yield return new object[]
        {
                    new IsValidParanthesisInput()
                    {
                       Input = "{[]}",
                       Result = true,
                    }
        };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
