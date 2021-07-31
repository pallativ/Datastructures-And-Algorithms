using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class WordBreakSolutionWithMemo
    {
        class PossibleCase
        {
            public bool IsPossible { get; set; }
            public List<string> Words { get; set; }
        }
        private List<string> result = new List<string>();
        private Dictionary<int, List<List<string>>> memo = new Dictionary<int, List<List<string>>>();
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            WordBreakTopDown(s, wordDict, 0);
            foreach (List<string> sentance in memo[0])
            {
                result.Add(string.Join(" ", sentance));
            }
            return result;
        }

        internal List<List<string>> WordBreakTopDown(string s, IList<string> wordDict, int start)
        {
            if (start == s.Length)
            {
                List<List<string>> solution = new List<List<string>> { new List<string>() };
                return solution;
            }

            if (memo.ContainsKey(start))
                return memo[start];
            else
                memo.Add(start, new List<List<string>>());

            for (int length = start + 1; length <= s.Length; length++)
            {
                var currentWord = s.Substring(start, length - start);
                if (wordDict.Contains(currentWord))
                {
                    var subSentances = WordBreakTopDown(s, wordDict, length);
                    foreach (var subSentace in subSentances)
                    {
                        var newSentance = new List<string>() { currentWord };
                        newSentance.AddRange(subSentace);
                        memo[start].Add(newSentance);
                    }
                }
            }
            return memo[start];
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
}
