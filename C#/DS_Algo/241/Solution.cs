using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures._241
{
    public class Solution
    {
        public IList<int> DiffWaysToCompute(string expression)
        {
            IList<int> ans = new List<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsOparator(expression[i]))
                {
                    var left = DiffWaysToCompute(expression[0..i]);
                    var right = DiffWaysToCompute(expression[(i + 1)..expression.Length]);
                    foreach (var num1 in left)
                    {
                        foreach (var num2 in right)
                        {
                            switch (expression[i])
                            {
                                case '+':
                                    ans.Add(num1 + num2);
                                    break;
                                case '-':
                                    ans.Add(num1 - num2);
                                    break;
                                case '*':
                                    ans.Add(num1 * num2);
                                    break;
                            }
                        }
                    }
                }
            }
            if (ans.Count == 0)
                ans.Add(Convert.ToInt32(expression));
            return ans;
        }
        private bool IsOparator(char op)
        {
            switch (op)
            {
                case '*':
                case '+':
                case '-':
                    return true;
                default:
                    return false;
            }
        }
    }
}
