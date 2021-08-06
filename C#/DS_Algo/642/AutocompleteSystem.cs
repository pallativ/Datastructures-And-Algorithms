using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Datastructures._642
{

    public class AutoCompleteResult
    {
        public string Result { get; set; }
        public int Times { get; set; }
    }
    public class AutoCompleteResultComparer : IComparer<AutoCompleteResult>
    {
        public int Compare([AllowNull] AutoCompleteResult x, [AllowNull] AutoCompleteResult y)
        {
            return y.Times == x.Times ? x.Result.CompareTo(y.Result) : y.Times.CompareTo(x.Times);
        }
    }

    public class AutocompleteSystem
    {
        private TrieNode root = new TrieNode();
        private TrieNode currentNode = null;
        private StringBuilder currentStringBuilder = new StringBuilder();
        public AutocompleteSystem(string[] sentences, int[] times)
        {
            for (int i = 0; i < sentences.Length; i++)
                BuildTrie(sentences[i], times[i]);
        }

        private void BuildTrie(string sentance, int times)
        {
            var current = root;
            currentNode = root;
            foreach (var ch in sentance)
            {
                if (!current.Map.ContainsKey(ch))
                {
                    current.Map.Add(ch, new TrieNode());
                }
                current = current.Map[ch];
            }
            if (times == 0)
                current.Times += 1;
            else
                current.Times = times;
        }
        public List<string> input(char c)
        {
            if (c != '#')
                currentStringBuilder.Append(c);
            if (c == '#')
            {
                BuildTrie(currentStringBuilder.ToString(), 0);
                currentStringBuilder.Clear();
            }
            else if (currentNode.Map.ContainsKey(c))
            {
                currentNode = currentNode.Map[c];
                var result = BuildResult(currentStringBuilder.ToString(), currentNode);
                result.Sort(new AutoCompleteResultComparer());
                var topResults = result.Take(3).Select(t => t.Result).ToList();
                return topResults;
            }
            return new List<string>();
        }
        public List<AutoCompleteResult> BuildResult(string prefix, TrieNode trieNode)
        {
            if (trieNode == null || trieNode.Map.Count == 0)
                return new List<AutoCompleteResult>() {
                    new AutoCompleteResult() { Result= prefix, Times = trieNode.Times }
                };
            var list = new List<AutoCompleteResult>();
            foreach (var item in trieNode.Map)
            {
                var currentResult = BuildResult(prefix + item.Key, item.Value);
                list.AddRange(currentResult);
            }
            return list;
        }
    }
}
