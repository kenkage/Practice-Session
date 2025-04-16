using System;

namespace test.Tries
{
    //   public class TrieNode
    //   {
    //       public TrieNode[] children { get; set; }
    //       public bool IsEndOfWord { get; set; }

    //       public TrieNode()
    //       {
    //           children = new TrieNode[26];
    //           IsEndOfWord = false;
    //       }
    //   }

    public class ImplementTrie
    {
        private TrieNode root;
        public ImplementTrie(TrieNode root)
        {
            this.root = root;
        }

        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char ch in word)
            {
                if (node.children[ch - 'a'] == null)
                {
                    node.children[ch - 'a'] = new TrieNode();
                }
                node = node.children[ch - 'a'];
            }
            node.IsEndOfWord = true;
            Console.WriteLine("Yes");
        }
    }
    public class TrieProgram
    {
        //public static void Main()
        //{
        //    TrieNode root = new TrieNode();

        //    //Console.WriteLine("Enter the number of words:");
        //    int n = int.Parse(Console.ReadLine());

        //    //Console.WriteLine("Enter the words:");
        //    string[] words = Console.ReadLine().Split();

        //    ImplementTrie trie = new ImplementTrie(root);

        //    foreach (var word in words)
        //    {
        //        trie.Insert(word);
        //    }
        //}
    }
}

