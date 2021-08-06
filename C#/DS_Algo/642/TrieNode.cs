using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures._642
{

    public class TrieNode
    {
        //public int Length { get; set; }
        public int Times { get; set; }
        public Dictionary<char, TrieNode> Map = new Dictionary<char, TrieNode>();
    }
}
