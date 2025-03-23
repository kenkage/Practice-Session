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

    public class WatchmenOfBinaryTree
	{
        static int watchmen;

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Enter the values in level-order traversal (-1 for null nodes):");
        //    List<int?> values = new List<int?>();

        //    string[] inputs = Console.ReadLine().Split();
        //    foreach (string input in inputs)
        //    {
        //        values.Add(input == "-1" ? (int?)null : int.Parse(input));
        //    }

        //    TreeNode root = BuildTreeFromInput(values);
        //    Console.WriteLine(MinWatchmen(root));
        //}

        private static TreeNode BuildTreeFromInput(List<int?> values)
        {
            if (values == null || values.Count == 0 || values[0] == null) return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(values[0].Value);
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Count)
            {
                TreeNode node = queue.Dequeue();

                if (values[i] != null)
                {
                    node.left = new TreeNode(values[i].Value);
                    queue.Enqueue(node.left);
                }
                i++;

                if (i < values.Count && values[i] != null)
                {
                    node.right = new TreeNode(values[i].Value);
                    queue.Enqueue(node.right);
                }
                i++;
            }
            return root;
        }


        public static int MinWatchmen(TreeNode root)
        {
            watchmen = 0;
            return (DFS(root) == 0) ? watchmen + 1 : watchmen;  //node is not covered. Case (0),
        }

        private static int DFS(TreeNode node)
        {
            if (node == null) return 2; // Node is covered Case (2)

            int left = DFS(node.left);
            int right = DFS(node.right);

            if (left == 0 || right == 0) //node is not covered. Case (0),
            {
                watchmen++;
                return 1; // This node is a watchman Case(1)
            }

            return (left == 1 || right == 1) ? 2 : 0; //If any child has a watchman Case(1), this node is covered case(2), else node is not covered. Case (0)
        }
    }
}

