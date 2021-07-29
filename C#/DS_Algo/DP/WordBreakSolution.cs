using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class WordBreakSolution
    {

        public bool IsWordBreakBruteForce(string s, string[] wordDictionary)
        {
            // sub probelms are : word with single character, two character, three characters.
            return IsWordBreakBruteForce(s, wordDictionary, 0);
        }
        public bool IsWordBreakBruteForce(string s, string[] wordDictionary, int start)
        {
            if (start == s.Length)
                return true;
            for (int end = start + 1; end <= s.Length; end++)
            {
                var word = s.Substring(start, end - start);
                if (Array.Exists(wordDictionary, t => t == word)
                    && IsWordBreakBruteForce(s, wordDictionary, end))
                    return true;
            }
            return false;
        }

        bool?[] memo;
        public bool IsWordBreakWithMemo(string s, string[] wordDictionary)
        {
            memo = new bool?[s.Length];
            return IsWordBreakWithMemo(s, wordDictionary, 0);
        }
        public bool IsWordBreakWithMemo(string s, string[] wordDictionary, int start)
        {
            if (start == s.Length)
                return true;
            if (memo[start] != null)
                return memo[start].Value;
            for (int end = start + 1; end <= s.Length; end++)
            {
                var word = s.Substring(start, end - start);
                if (Array.Exists(wordDictionary, t => t == word)
                    && IsWordBreakWithMemo(s, wordDictionary, end))
                    return (memo[start] = true).Value;
            }
            return (memo[start] = false).Value;
        }

        [Fact]
        public void Test()
        {
            bool result;
            result = IsWordBreakBruteForce("leetcode", new string[] { "leet", "code" });
            Assert.True(result);
            result = IsWordBreakBruteForce("applepenapple", new string[] { "apple", "pen" });
            Assert.True(result);
            result = IsWordBreakBruteForce("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" });
            Assert.False(result);
            //result = IsWordBreakBruteForce("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" });
            //Assert.False(result);
        }

        [Fact]
        public void TestWithMemo()
        {
            bool result;
            result = IsWordBreakWithMemo("leetcode", new string[] { "leet", "code" });
            Assert.True(result);
            result = IsWordBreakWithMemo("applepenapple", new string[] { "apple", "pen" });
            Assert.True(result);
            result = IsWordBreakWithMemo("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" });
            Assert.False(result);
            result = IsWordBreakWithMemo("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" });
            Assert.False(result);

        }


    }
}
