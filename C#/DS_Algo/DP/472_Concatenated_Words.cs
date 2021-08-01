using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class ConcatenatedWords
    {
        private Dictionary<int, List<List<string>>> memo = new Dictionary<int, List<List<string>>>();
        private Dictionary<int, bool> boolMemo = new Dictionary<int, bool>();
        private HashSet<string> wordsHashSet = new HashSet<string>();
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            foreach (var word in words)
            {
                wordsHashSet.Add(word);
            }
            var result = new List<string>();
            //foreach (var sentance in words)
            //{
            //    memo.Clear();
            //    if (WordBreak(sentance))
            //        result.Add(sentance);
            //}
            //return result;

            foreach (var sentance in words)
            {
                boolMemo.Clear();
                if (WordBreak(sentance, 0))
                    result.Add(sentance);
            }
            return result;
        }

        public bool WordBreak(string s)
        {
            WordBreakMemo(s, 0);
            foreach (var item in memo[0])
            {
                if (item.Count >= 2)
                    return true;
            }
            return false;
        }


        internal bool WordBreak(string s, int start)
        {
            if (start == s.Length)
                return true;

            if (boolMemo.ContainsKey(start))
                return boolMemo[start];

            for (int length = start + 1; length <= s.Length; length++)
            {
                var currentWord = s[start..length];
                if (currentWord != s && wordsHashSet.Contains(currentWord) && WordBreak(s, length))
                {
                    boolMemo.Add(start, true);
                    return boolMemo[start];
                }
            }
            boolMemo.Add(start, false);
            return boolMemo[start];
        }
        internal List<List<string>> WordBreakMemo(string s, int start)
        {
            if (start == s.Length)
                return new List<List<string>>() { new List<string>() };

            if (memo.ContainsKey(start))
                return memo[start];
            else
                memo.Add(start, new List<List<string>>());

            for (int length = start + 1; length <= s.Length; length++)
            {
                var currentWord = s[start..length];
                if (wordsHashSet.Contains(currentWord))
                {
                    var postfixSentances = WordBreakMemo(s, length);
                    foreach (var sentance in postfixSentances)
                    {
                        var newSentance = new List<string>(sentance) { currentWord };
                        memo[start].Add(newSentance);
                    }
                }
            }
            return memo[start];
        }

        [Theory]
        [ClassData(typeof(GenerateConcatenatedWordInput))]
        public void Test(ConcatenatedWordInput input)
        {
            var actual = FindAllConcatenatedWordsInADict(input.WordsDictionary.ToArray());
            Assert.Equal(input.Result, actual);
        }
    }

    public class ConcatenatedWordInput
    {
        public List<string> WordsDictionary { get; set; }
        public List<string> Result { get; set; }
    }
    public class GenerateConcatenatedWordInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new ConcatenatedWordInput()
                    {
                       WordsDictionary = new List<string> (){ "cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat" },
                       Result = new List<string> (){ "catsdogcats", "dogcatsdog", "ratcatdogcat" }
                    }
            };
            yield return new object[]
            {
                    new ConcatenatedWordInput()
                    {
                       WordsDictionary = new List<string> (){"cat","dog","catdog"},
                       Result = new List<string> (){ "catdog" }
                    }
            };

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
