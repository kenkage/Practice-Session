using System;
namespace test.BinaryTrees
{
	//public class TreeNode
	//{
	//	public int val;
	//	public TreeNode left;
	//	public TreeNode right;

	//	public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
	//	{
	//		this.val = val;
	//		this.left = left;
	//		this.right = right;
	//	}
	//}

	public class MinimumriskPathInBST
	{
        private int minDiff = int.MaxValue;
        private TreeNode prev = null;

		//public static void Main()
		//{
		//	string[] values = Console.ReadLine().Split();
		//	int n = values.Length;

		//	List<int> nodes = new List<int>();
		//	for(int i = 0; i < n; i++)
		//	{
		//		nodes.Add(int.Parse(values[i]));
		//	}
		//	TreeNode root = BuildTree(nodes);
		//	MinimumriskPathInBST sol = new MinimumriskPathInBST();
  //          Console.WriteLine(sol.GetMinimumDifference(root));
  //      }

		static TreeNode BuildTree(List<int> nodes)
		{
			if (nodes == null || nodes.Count == 0 || nodes[0] == -1) return null;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			TreeNode root = new TreeNode(nodes[0]);
			queue.Enqueue(root);

			int i = 1;
			while(i< nodes.Count)
			{
				TreeNode curr = queue.Dequeue();

				if(i<nodes.Count && nodes[i] != -1)
				{
					curr.left = new TreeNode(nodes[i]);
					queue.Enqueue(curr.left);
				}
				i++;

                if (i < nodes.Count && nodes[i] != -1)
                {
                    curr.right = new TreeNode(nodes[i]);
                    queue.Enqueue(curr.right);
                }
                i++;
            }
			return root;
		}

        public int GetMinimumDifference(TreeNode root)
        {
            minDiff = int.MaxValue;
            prev = null;
            InOrder(root);
            return minDiff;
        }

        private void InOrder(TreeNode root)
        {
            if (root == null) return;

            InOrder(root.left);

            if (prev != null)
                minDiff = Math.Min(minDiff, root.val - prev.val);
            prev = root;

            InOrder(root.right);
        }
    }
}

