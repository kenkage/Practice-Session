using System;
namespace test.Tries
{
    public class RemoveWordTrieNode
    {
        public RemoveWordTrieNode[] children = new RemoveWordTrieNode[52];
        public bool IsEndOfWord = false;
    }

    public class RemoveWord
	{
        RemoveWordTrieNode root;
		public RemoveWord()
		{
            root = new RemoveWordTrieNode();
		}

        private int GetIndex(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return c - 'A'; // 0–25
            else if (c >= 'a' && c <= 'z')
                return 26 + (c - 'a'); // 26–51
            else
                throw new ArgumentException("Only alphabets A-Z or a-z are allowed.");
        }

        public void Insert(string word)
        {
            RemoveWordTrieNode node = root;

            foreach(char ch in word)
            {
                int index = GetIndex(ch);
                if (node.children[index] == null)
                {
                    node.children[index] = new RemoveWordTrieNode();
                }
                node = node.children[index];
            }
            node.IsEndOfWord = true;
        }

        public bool Remove(string word)
        {
            return RemoveHelper(root, word, 0);
        }

        private bool RemoveHelper(RemoveWordTrieNode node, string word, int index)
        {
            if (index == word.Length)
            {
                if (!node.IsEndOfWord)
                    return false; // word not found

                node.IsEndOfWord = false;

                // if no children, node can be deleted
                return IsEmpty(node);
            }

            int charIndex = GetIndex(word[index]);
            RemoveWordTrieNode child = node.children[charIndex];
            if (child == null)
                return false; // word not found

            bool shouldDeleteChild = RemoveHelper(child, word, index + 1);

            if (shouldDeleteChild)
            {
                node.children[charIndex] = null;
                return IsEmpty(node) && !node.IsEndOfWord;
            }

            return false;
        }

        private bool IsEmpty(RemoveWordTrieNode node)
        {
            for (int i = 0; i < 52; i++)
            {
                if (node.children[i] != null)
                    return false;
            }
            return true;
        }

        public bool Exists(string word)
        {
            RemoveWordTrieNode node = root;
            foreach (char c in word)
            {
                int index = GetIndex(c);
                if (node.children[index] == null)
                    return false;
                node = node.children[index];
            }
            return node.IsEndOfWord;
        }
    }

    public class RemoveWordProgram
    {
        public static void Run()
        {
           string[] insertWords = Console.ReadLine().Split();
           string[] removeWords = Console.ReadLine().Split();

           RemoveWord trie = new RemoveWord();

           // Insert words into trie
           foreach (string word in insertWords)
               trie.Insert(word);

           // Remove words from trie
           foreach (string word in removeWords)
           {
               if (trie.Exists(word))
               {
                   trie.Remove(word);
                   Console.WriteLine("Removed");
               }
               else
               {
                   Console.WriteLine("Not Found");
               }
           }
        }
    }
}

