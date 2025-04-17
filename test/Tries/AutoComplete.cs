using System;
namespace test.Tries
{
	public class TrieNode
	{
		public TrieNode[] children = new TrieNode[26];
		public bool IsEndOfWord = false;
	}

	public class AutoComplete
	{
		private TrieNode root;

		public AutoComplete()
		{
			root = new TrieNode();
		}

		public void Insert(string word)
		{
			TrieNode node = root;
			foreach(char ch in word)
			{
				int index = ch - 'a';
				if (node.children[index] == null)
				{
					node.children[index] = new TrieNode();
				}
				node = node.children[index];
			}
			node.IsEndOfWord = true;
		}

		public TrieNode Search(string prefix)
		{
            TrieNode node = root;
            foreach (char ch in prefix)
            {
                int index = ch - 'a';
                if (node.children[index] == null) return null;
                node = node.children[index];
            }
            return node;
        }

		public List<string> AutoCompleteText(string prefix)
		{
			TrieNode prefixNode = Search(prefix);
			List<string> result = new List<string>();

			if (prefixNode == null) return result;

			DFS(prefixNode, prefix, result);
			result.Sort();
			return result;
		}

        private void DFS(TrieNode node, string currentPrefix, List<string> result)
        {
			if (node == null) return;

			if (node.IsEndOfWord)
			{
				result.Add(currentPrefix);
			}

			for(char ch = 'a'; ch <= 'z'; ch++)
			{
				int index = ch - 'a';
				if (node.children[index] != null)
				{
					DFS(node.children[index], currentPrefix + ch, result);
				}
			}
        }
    }

	public class AutoCompleteProgram
	{
		public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            AutoComplete trie = new AutoComplete();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine().ToLower();
                trie.Insert(word);
            }

            string prefix = Console.ReadLine().ToLower();

            List<string> autoCompleteResult = trie.AutoCompleteText(prefix);

            if (autoCompleteResult.Count == 0)
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine(string.Join(" ", autoCompleteResult));
            }
        }
    }
}

