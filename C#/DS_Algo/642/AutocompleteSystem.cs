using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures._642
{
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
            current.Times = times;
        }
        public List<string> input(char c)
        {
            if (c == '#')
            {
                //Search
            }
            else if (currentNode.Map.ContainsKey(c))
            {
                currentStringBuilder.Append(c);
                currentNode = currentNode.Map[c];
                var result = BuildResult(currentStringBuilder.ToString(), currentNode);
                return result;
            }
            return new List<string>();
        }
        public List<string> BuildResult(string prefix, TrieNode trieNode)
        {
            if (trieNode == null || trieNode.Map.Count == 0)
                return new List<string>() { prefix };
            var list = new List<string>();
            foreach (var item in trieNode.Map)
            {
                var currentResult = BuildResult(prefix + item.Key, item.Value);
                list.AddRange(currentResult);
            }
            return list;
        }
    }
}
