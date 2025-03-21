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

    public class ConcatenateNodes
	{
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
        //    Concatenate(root);
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

        private static void Concatenate(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            List<string> nodeValue = new List<string>();

            while(queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                nodeValue.Add(current.val.ToString());

                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }
            nodeValue.Sort((a, b) => (b + a).CompareTo(a + b));
            Console.WriteLine(string.Join("", nodeValue));
        }
    }
}

