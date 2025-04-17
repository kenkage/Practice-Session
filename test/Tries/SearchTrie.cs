using System;
namespace test.Tries
{
	//public class TrieNode
	//{
	//	public TrieNode[] children = new TrieNode[26];
	//	public bool IsEndOfWord = false;
	//}

	public class SearchTrie
	{
		private TrieNode root;
		public SearchTrie(TrieNode root)
		{
			this.root = root;
		}

        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char ch in word)
            {
                int index = ch - 'a';
                if (node.children[index] == null)
                {
                    node.children[index] = new TrieNode(); //If there’s no existing path (child node) for the current character,
                                                              //we need to create a new node to continue building the path.
                }
                node = node.children[index];
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
		{
			TrieNode node = root;

			foreach(char ch in word)
			{
                int index = ch - 'a';
                if (node.children[index] == null)
				{
					return false;
				}
				node = node.children[index];
            }
			return node.IsEndOfWord;
		}
	}
	public class SearchProgramTrie
	{
		//public static void Main()
		//{
  //          TrieNode root = new TrieNode();
  //          SearchTrie trie = new SearchTrie(root);

  //          Console.WriteLine("Enter number of words to insert in Trie:");
  //          int n = int.Parse(Console.ReadLine());

  //          Console.WriteLine("Enter the words to insert:");
  //          string[] insertWords = Console.ReadLine().Split();

  //          foreach (var word in insertWords)
  //          {
  //              trie.Insert(word);
  //          }

  //          Console.WriteLine("Enter the words to search:");
  //          string[] searchWords = Console.ReadLine().Split();

  //          foreach (var word in searchWords)
  //          {
  //              Console.WriteLine(trie.Search(word) ? "Yes" : "No");
  //          }
  //      }
	}
}

