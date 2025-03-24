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

    public class ThreeNumbersProduct
	{
        //static void Main()
        //{
        //    Console.WriteLine("Enter number of nodes:");
        //    int n = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Enter level-order values (-1 for null nodes):");
        //    List<int?> values = new List<int?>();
        //    string[] inputs = Console.ReadLine().Split();
        //    foreach (string input in inputs)
        //    {
        //        values.Add(input == "-1" ? (int?)null : int.Parse(input));
        //    }

        //    Console.WriteLine("Enter target product:");
        //    int k = int.Parse(Console.ReadLine());

        //    TreeNode root = BuildTreeFromInput(values);
        //    bool result = FindThreeProduct(root, k);

        //    Console.WriteLine(result.ToString().ToLower());
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

        private static bool FindThreeProduct(TreeNode root, int k)
        {
            List<int> nodes = new List<int>();
            InOrderTraversal(root, nodes);

            int n = nodes.Count;
            for (int i = 0; i < n - 2; i++)
            {
                int left = i + 1, right = n - 1;
                while (left < right)
                {
                    long product = (long)nodes[i] * nodes[left] * nodes[right];

                    if (product == k) return true;
                    else if (product < k) left++;
                    else right--;
                }
            }
            return false;
        }

        private static void InOrderTraversal(TreeNode root, List<int> nodes)
        {
            if (root == null) return;
            InOrderTraversal(root.left, nodes);
            nodes.Add(root.val);
            InOrderTraversal(root.right, nodes);
        }
    }
}

