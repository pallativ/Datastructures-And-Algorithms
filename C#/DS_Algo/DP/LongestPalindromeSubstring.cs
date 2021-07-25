using System.Collections.Generic;
using Xunit;

namespace Datastructures.DP
{
    public class LongestPalindromeSubstring
    {
        private int maxLength = 1;
        private int start = 0, end = 0;
        private Dictionary<string, bool> memo = new Dictionary<string, bool>();
        public string LongestPalindrome(string s)
        {
            LongestPalindrome(s, 0, s.Length - 1);
            return s.Substring(start, maxLength);
        }
        public void LongestPalindrome(string s, int i, int j)
        {
            if (IsPalindrome(s, i, j, memo))
            {
                var currentPalindromeLength = j - i + 1;
                if (currentPalindromeLength > maxLength)
                {
                    start = i;
                    end = j;
                    maxLength = currentPalindromeLength;
                }
            }
            else
            {
                if (maxLength < j - i)
                {
                    LongestPalindrome(s, i, j - 1);
                    LongestPalindrome(s, i + 1, j);
                }
            }
        }
        private bool IsPalindrome(string s, int i, int j,
            Dictionary<string, bool> memo)
        {
            var key = $"{i},{j}";
            if (memo.ContainsKey(key))
                return memo[key];
            if (i == j)
            {
                memo.Add(key, true);
            }
            else if (s[i] == s[j])
            {
                if (i + 1 == j)
                    memo.Add(key, true);
                else
                    memo.Add(key, IsPalindrome(s, i + 1, j - 1, memo));
            }
            else
                memo.Add(key, false);
            return memo[key];
        }
    }

    public class LongestPalindromeSubstringTests
    {
        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("cbbd", "bb")]
        [InlineData("a", "a")]
        [InlineData("ac", "a")]
        [InlineData("abbcccbbbcaaccbababcbcabca", "bbcccbb")]
        [InlineData("babaddtattarrattatddetartrateedredividerb", "ddtattarrattatdd")]
        public void Test(string inputString, string expected)
        {
            var lcs = new LongestPalindromeSubstring();
            var actual = lcs.LongestPalindrome(inputString);
            Assert.Equal(actual, expected);
        }
    }
}
