using System;
namespace test.BinaryTrees
{
    //public class TreeNode
    //{
    //    public int val;
    //    public TreeNode left;
    //    public TreeNode right;

    //    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    //    {
    //        this.val = val;
    //        this.left = left;
    //        this.right = right;
    //    }
    //}

    public class ZigZagTravesal
	{
        private int ans = 0;
        //static void Main(string[] args)
        //{
        //    TreeNode root = BuildTree();

        //    ZigZagTravesal sol = new ZigZagTravesal();
        //    int result = sol.maxZigzagStudents(root);
        //    Console.WriteLine(result);
        //}

        public int maxZigzagStudents(TreeNode root)
        {
            dfs(root, 1, 1);
            return ans;
        }

        private void dfs(TreeNode root, int l, int r)
        {
            if (root == null)
            {
                return;
            }
            ans = Math.Max(ans, Math.Max(l, r));
            dfs(root.left, r + 1, 0);
            dfs(root.right, 0, l + 1);
        }

        public static TreeNode BuildTree()
        {
            // Console.WriteLine("Enter tree nodes in level order (use 'N' for null nodes):");
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

