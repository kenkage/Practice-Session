using System;
using System.Collections.Generic;

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

	public class MaxSum_TopView_BinaryTree
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Enter the values in level-order traversal (-1 for null nodes):");
			List<int?> values = new List<int?>();

			string[] inputs = Console.ReadLine().Split();
			foreach(string input in inputs)
			{
				values.Add(input == "-1" ? (int?)null : int.Parse(input));
			}

			TreeNode root = BuildTreeFromInput(values);
			Solution solution = new Solution();
			Console.WriteLine(solution.MaxSumTopView(root));
        }

        private static TreeNode BuildTreeFromInput(List<int?> values)
        {
			if (values == null || values.Count == 0 || values[0] == null) return null;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			TreeNode root = new TreeNode(values[0].Value);
			queue.Enqueue(root);
			int i = 1;

			while(i < values.Count)
			{
				TreeNode node = queue.Dequeue();

				if (values[i] != null)
				{
					node.left = new TreeNode(values[i].Value);
					queue.Enqueue(node.left);
				}
				i++;

				if(i < values.Count && values[i] != null)
				{
					node.right = new TreeNode(values[i].Value);
					queue.Enqueue(node.right);
				}
				i++;
			}
			return root;
        }
    }

    public class Solution
    {
        public int MaxSumTopView(TreeNode root)
        {
            if (root == null) return 0;

            Dictionary<int, int> topViewMap = new Dictionary<int, int>();
            Queue<(TreeNode node, int hd)> queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var (node, hd) = queue.Dequeue();

                if (!topViewMap.ContainsKey(hd))
                {
                    topViewMap[hd] = node.val;
                }

                if (node.left != null) queue.Enqueue((node.left, hd - 1));
                if (node.right != null) queue.Enqueue((node.right, hd + 1));
            }

            int[] topViewValues = new List<int>(topViewMap.Values).ToArray();
            return MaxSubarraySum(topViewValues);
        }

        private int MaxSubarraySum(int[] arr)
        {
            int maxSum = arr[0], currentSum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                currentSum = Math.Max(arr[i], currentSum + arr[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }
            return maxSum;
        }
    }
}

