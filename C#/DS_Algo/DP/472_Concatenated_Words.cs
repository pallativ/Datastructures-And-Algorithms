using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Datastructures.DP
{
    public class ConcatenatedWords
    {
        private Dictionary<int, bool> boolMemo = new Dictionary<int, bool>();
        private HashSet<string> wordsHashSet = new HashSet<string>();
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            foreach (var word in words)
            {
                wordsHashSet.Add(word);
            }
            var result = new List<string>();
            foreach (var sentance in words)
            {
                boolMemo.Clear();
                if (!string.IsNullOrEmpty(sentance) && WordBreak(sentance, 0))
                    result.Add(sentance);
            }
            return result;
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
                // currentWord != s - Important to skip the ones which are one word length.
                if (currentWord != s && wordsHashSet.Contains(currentWord) && WordBreak(s, length))
                {
                    boolMemo.Add(start, true);
                    return boolMemo[start];
                }
            }
            boolMemo.Add(start, false);
            return boolMemo[start];
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
