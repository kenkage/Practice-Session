using System;
namespace test.Tries
{
    // Shared TrieNode used across Trie problems (lowercase a-z)
    public class TrieNode
    {
        public TrieNode[] children { get; set; }
        public bool IsEndOfWord { get; set; }

        public TrieNode()
        {
            children = new TrieNode[26];
            IsEndOfWord = false;
        }
    }
}
