using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class WordBreakBruteforce
    {
        public bool IsWordBreakPossible(string s, string[] wordDictionary)
        {
            // sub probelms are : word with single character, two character, three characters.
            return IsWordBreakPossible(s, wordDictionary, 0);
        }
        public bool IsWordBreakPossible(string s, string[] wordDictionary, int start)
        {
            if (start == s.Length)
                return true;
            for (int length = 1; length <= s.Length - start; length++)
            {
                int j = start;
                while (j < s.Length)
                {
                    var word = s.Substring(j, length);
                    if (!Array.Exists(wordDictionary, t => t == word))
                        break;
                    j += word.Length;
                    return IsWordBreakPossible(s, wordDictionary, j);
                }
            }
            return false;
        }

        [Fact]
        public void Test()
        {
            bool result;
            result = IsWordBreakPossible("leetcode", new string[] { "leet", "code" });
            Assert.True(result);
            result = IsWordBreakPossible("applepenapple", new string[] { "apple", "pen" });
            Assert.True(result);
            result = IsWordBreakPossible("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" });
            Assert.False(result);
        }
    }
}
