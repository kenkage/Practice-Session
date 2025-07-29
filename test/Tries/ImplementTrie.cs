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
                    node.children[ch - 'a'] = new TrieNode();  //If there’s no existing path (child node) for the current character,
                }                                              //we need to create a new node to continue building the path i.e. reference node 
                node = node.children[ch - 'a']; // reference node is nww node; further addition to be made in reference node.
            }
            node.IsEndOfWord = true;
            Console.WriteLine("Yes");
        }
    }
    public class TrieProgram
    {
        public static void Main()
        {
            TrieNode root = new TrieNode();

            //Console.WriteLine("Enter the number of words:");
            int n = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the words:");
            string[] words = Console.ReadLine().Split();

            ImplementTrie trie = new ImplementTrie(root);

            foreach (var word in words)
            {
                trie.Insert(word);
            }
        }
    }
}

