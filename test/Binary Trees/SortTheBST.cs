using System;
namespace test.BinaryTrees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left, right;

        public TreeNode(int val = 0)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class SortTheBST
	{
        public static void Main()
        {
            int t = int.Parse(Console.ReadLine());

            for (int test = 0; test < t; test++)
            {
                string[] input = Console.ReadLine().Split();
                TreeNode root = BuildBST(input);

                List<int> sorted = new List<int>();
                InOrder(root, sorted);

                Console.WriteLine(string.Join(" ", sorted));
            }
        }

        public static TreeNode BuildBST(string[] nodes)
        {
            if (nodes.Length == 0 || nodes[0] == "N") return null;

            TreeNode root = new TreeNode(int.Parse(nodes[0]));
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (queue.Count > 0 && i < nodes.Length)
            {
                TreeNode current = queue.Dequeue();

                if (i < nodes.Length && nodes[i] != "N")
                {
                    current.left = new TreeNode(int.Parse(nodes[i]));
                    queue.Enqueue(current.left);
                }
                i++;

                if (i < nodes.Length && nodes[i] != "N")
                {
                    current.right = new TreeNode(int.Parse(nodes[i]));
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }

        public static void InOrder(TreeNode root, List<int> result)
        {
            if (root == null) return;
            InOrder(root.left, result);
            result.Add(root.val);
            InOrder(root.right, result);
        }
    }
}

