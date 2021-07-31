using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class Solution
    {
        class PossibleCase
        {
            public bool IsPossible { get; set; }
            public List<string> Words { get; set; }
        }
        private List<string> result = new List<string>();
        private Dictionary<int, PossibleCase> memo = new Dictionary<int, PossibleCase>();
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            WordBreak(s, wordDict, 0, new List<string>());
            return result;
        }

        internal void WordBreak(string s, IList<string> wordDict, int start, IList<string> words)
        {
            if (start == s.Length)
                result.Add(string.Join(" ", words));

            for (int length = start + 1; length <= s.Length; length++)
            {
                var current = s.Substring(start, length - start);
                if (wordDict.Contains(current))
                {
                    var newWordsList = new List<string>(words) { current };
                    WordBreak(s, wordDict, length, newWordsList);
                }
            }
        }

        [Theory]
        [ClassData(typeof(GenerateData))]
        public void Test(WordBreakInput wordBreakInput)
        {
            List<string> result = WordBreak(wordBreakInput.Sentance, wordBreakInput.WordsDictionary).ToList();
            result.Sort();
            wordBreakInput.Result.Sort();
            Assert.Equal(wordBreakInput.Result, result);
        }
    }



    public class WordBreakInput
    {
        public string Sentance { get; set; }
        public List<string> WordsDictionary { get; set; }
        public List<string> Result { get; set; }
    }
    public class GenerateData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new WordBreakInput()
                    {
                       Sentance = "catsanddog",
                       WordsDictionary = new List<string> (){ "cat", "cats", "and", "sand", "dog" },
                       Result = new List<string> (){ "cats and dog", "cat sand dog" }
                    }
            };
            yield return new object[]
            {
                    new WordBreakInput()
                    {
                       Sentance = "pineapplepenapple",
                       WordsDictionary = new List<string> (){"apple","pen","applepen","pine","pineapple"},
                       Result = new List<string> (){ "pine apple pen apple", "pineapple pen apple", "pine applepen apple" }
                    }
            };

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
