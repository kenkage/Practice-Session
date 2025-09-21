using System;
namespace test.Tries
{
    class XORTrieNode
    {
        public XORTrieNode[] Children = new XORTrieNode[2]; // 0 and 1
    }

    class BinaryTrie
    {
        private XORTrieNode root;

        public BinaryTrie()
        {
            root = new XORTrieNode();
        }

        // Insert number in 32-bit representation
        public void Insert(int num)
        {
            XORTrieNode node = root;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1; // bit value
                // int bit = (num & (1 << i)) != 0 ? 1 : 0;  // convert mask → 0/1
                if (node.Children[bit] == null)
                    node.Children[bit] = new XORTrieNode();
                node = node.Children[bit];
            }
        }

        // Find max XOR for num with Trie
        public int GetMaxXor(int num)
        {
            XORTrieNode node = root;
            int maxXor = 0;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;// bit value
                // int bit = (num & (1 << i)) != 0 ? 1 : 0;  // convert mask → 0/1
                int oppositeBit = 1 - bit;

                if (node.Children[oppositeBit] != null)
                {
                    maxXor = maxXor | (1 << i); // turns on i-th bit w/o affecting others
                    node = node.Children[oppositeBit];
                }
                else
                {
                    node = node.Children[bit];
                }
            }
            return maxXor;
        }
    }

    public class MaximumXOR_Pair
	{
        static int FindMaximumXOR(int[] arr)
        {
            BinaryTrie trie = new BinaryTrie();
            int maxXor = 0;

            // Insert first number
            trie.Insert(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                int num = arr[i];
                // Get best XOR with current num
                maxXor = Math.Max(maxXor, trie.GetMaxXor(num));
                // Insert current num into Trie
                trie.Insert(num);
            }

            return maxXor;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(input[i]);

            Console.WriteLine(FindMaximumXOR(arr));
        }
    }
}

