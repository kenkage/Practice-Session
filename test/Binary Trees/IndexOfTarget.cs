using System;
namespace test.BinaryTrees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class IndexOfTarget
	{
		static void Main(string[] stirngs)
        {
            Console.WriteLine("Enter the values in level-order traversal (-1 for null nodes):");
            List<int?> values = new List<int?>();

            string[] inputs = Console.ReadLine().Split();
            foreach (string input in inputs)
            {
                values.Add(input == "-1" ? (int?)null : int.Parse(input));
            }

            TreeNode root = BuildTreeFromInput(values);
            Solution solution = new Solution();
        }

        private static TreeNode BuildTreeFromInput(List<int?> values)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(values[0].Value);
            queue.Enqueue(root);
            int i = 1;

            while(values.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (values[i] != null)
                {
                    node.left = new TreeNode(values[0].Value);
                    queue.Enqueue(node.left);
                }
                i++;
                if (i < values.Count && values.Count > 0)
                {
                    node.right = new TreeNode(values[0].Value);
                    queue.Enqueue(node.right);
                }
            }
            return root;
        }
    }
}

