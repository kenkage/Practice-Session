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

    public class ZigZagTraversal
	{
        static void Main(string[] args)
        {
            TreeNode root = BuildTree();

            ZigZagTraversal sol = new ZigZagTraversal();
            int result = sol.LongestZigzag(root);
            Console.WriteLine(result);
        }

        private int maxZigzagLength = 0;

        public int LongestZigzag(TreeNode root)
        {
            if (root == null) return 0;

            // Start zigzag from both the left and right child of the root
            ZigzagHelper(root, 1, true);  // Initial move left
            ZigzagHelper(root, 1, false); // Initial move right

            return maxZigzagLength;
        }

        private void ZigzagHelper(TreeNode node, int length, bool isLeft)
        {
            if (node == null) return;

            // Update maximum zigzag length
            maxZigzagLength = Math.Max(maxZigzagLength, length);

            if (isLeft)
            {
                // Continue zigzag to the right
                ZigzagHelper(node.right, length + 1, false);
                // Restart zigzag on the left
                ZigzagHelper(node.left, 1, true);
            }
            else
            {
                // Continue zigzag to the left
                ZigzagHelper(node.left, length + 1, true);
                // Restart zigzag on the right
                ZigzagHelper(node.right, 1, false);
            }
        }

        // Method to take user input and construct the binary tree
        public static TreeNode BuildTree()
        {
            Console.WriteLine("Enter tree nodes in level order (use 'N' for null nodes):");
            string[] values = Console.ReadLine().Split(' ');

            if (values.Length == 0 || values[0] == "N") return null;

            TreeNode root = new TreeNode(int.Parse(values[0]));
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Length)
            {
                TreeNode currentNode = queue.Dequeue();

                // Add left child
                if (values[i] != "N")
                {
                    currentNode.left = new TreeNode(int.Parse(values[i]));
                    queue.Enqueue(currentNode.left);
                }
                i++;

                if (i >= values.Length) break;

                // Add right child
                if (values[i] != "N")
                {
                    currentNode.right = new TreeNode(int.Parse(values[i]));
                    queue.Enqueue(currentNode.right);
                }
                i++;
            }

            return root;
        }

    }
}

