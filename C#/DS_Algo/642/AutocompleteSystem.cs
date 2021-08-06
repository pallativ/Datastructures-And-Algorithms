using System.Collections.Generic;

namespace Datastructures._642
{
    public class AutocompleteSystem
    {
        private TrieNode root = new TrieNode();
        public AutocompleteSystem(string[] sentences, int[] times)
        {
            for (int i = 0; i < sentences.Length; i++)
                BuildTrie(sentences[i], times[i]);
        }

        private void BuildTrie(string sentance, int times)
        {
            var current = root;
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
            return null;
        }
    }
}
