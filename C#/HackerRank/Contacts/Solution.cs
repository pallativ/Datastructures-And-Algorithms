using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Contacts
{
    public class Solution
    {
        class TrieNode
        {
            public readonly Dictionary<char, TrieNode> maps;
            public bool IsComplete { get; set; }
            public int Count { get; set; }
            public TrieNode() => maps = new Dictionary<char, TrieNode>();
            public TrieNode this[char ch]
            {
                get => maps[ch];
                set => maps[ch] = value;
            }
            public bool Contains(char ch)
            {
                return maps.ContainsKey(ch);
            }
        }
        private readonly TrieNode root = new TrieNode();
        public void Add(string name)
        {
            var current = root;
            foreach (var ch in name)
            {
                if (!current.Contains(ch))
                    current[ch] = new TrieNode();
                current = current[ch];
                current.Count++;
            }
            current.IsComplete = true;
        }
        public int Find(string partialName)
        {
            var current = root;
            foreach (var ch in partialName)
            {
                if (current.Contains(ch))
                    current = current[ch];
                else
                    return 0;
            }
            return current.Count;
        }
        public bool IsGoodSet(string name)
        {
            var current = root;
            foreach (var ch in name)
            {
                if (!current.Contains(ch))
                    current[ch] = new TrieNode();
                current = current[ch];
                if (current.IsComplete)
                    return false;
                current.Count++;
            }
            current.IsComplete = true;
            return true;
        }

        public List<string> Get(string partialName)
        {
            var current = root;
            foreach (var ch in partialName)
            {
                if (current.Contains(ch))
                    current = current[ch];
                else
                    return new List<string>();
            }
            var result = new List<string>();
            result.AddRange(Traverse(current, partialName));
            return result;
        }
        private List<string> Traverse(TrieNode trieNode, string value)
        {
            if (trieNode == null || trieNode.maps.Count == 0)
                return new List<string>() { value };
            var result = new List<string>();
            if(trieNode.IsComplete)
                result.Add(value);
            foreach(KeyValuePair<char, TrieNode> keyValuePair  in trieNode.maps)
            {
                var newValue = string.Format($"{value}{keyValuePair.Key}");
                var list = Traverse(keyValuePair.Value, newValue);
                result.AddRange(list);
            }
            return result;
        }
    }
}
