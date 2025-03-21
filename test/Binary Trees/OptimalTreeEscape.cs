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
    public class OptimalTreeEscape
	{
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the values in level-order traversal (-1 for null nodes):");
            List<int?> values = new List<int?>();

            string[] inputs = Console.ReadLine().Split();
            foreach (string input in inputs)
            {
                values.Add(input == "-1" ? (int?)null : int.Parse(input));
            }

            TreeNode root = BuildTreeFromInput(values);
            OptimalTreeEscape solution = new OptimalTreeEscape();
            Console.WriteLine(solution.WhoEscapesFirst(root));
        }

        private static TreeNode BuildTreeFromInput(List<int?> values)
        {
            if (values == null || values.Count == 0 || values[0] == null) return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(values[0].Value);
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Count)
            {
                TreeNode current = queue.Dequeue();

                if (values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;    

                if (i < values.Count && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }
            return root;
        }

        public int WhoEscapesFirst(TreeNode root)
        {
            if (root == null) return 0;

            int leftDepth = GetLeftDepth(root);
            int rightDepth = GetRightDepth(root);

            if (leftDepth < rightDepth) return -1; //left escapes first
            if (rightDepth < leftDepth) return 1;  //right escaped first
            return 0;
        }

        private int GetLeftDepth(TreeNode node)
        {
            int depth = 0;
            while (node != null)
            {
                depth++;
                node = node.left;
            }
            return depth;
        }

        private int GetRightDepth(TreeNode node)
        {
            int depth = 0;
            while (node != null)
            {
                depth++;
                node = node.right;
            }
            return depth;
        }
    }
}

