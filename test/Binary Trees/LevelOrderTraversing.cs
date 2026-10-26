using System;
using System.Collections.Generic;

namespace test.BinaryTrees
{
    // TreeNode is defined in Models/TreeNode.cs

    public class LevelOrderSolution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> levelNodes = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();
                    levelNodes.Add(current.val);

                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                }
                result.Add(levelNodes);
            }
            return result;
        }
    }

    public class LevelOrderTraversing
    {
        static TreeNode BuildTreeFromInput(List<int?> values)
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

        public static void Run()
        {
            Console.WriteLine("Enter the values in level-order traversal (-1 for null nodes):");
            List<int?> values = new List<int?>();

            string[] inputs = Console.ReadLine().Split();
            foreach (string input in inputs)
            {
                values.Add(input == "-1" ? (int?)null : int.Parse(input));
            }

            TreeNode root = BuildTreeFromInput(values);
            LevelOrderSolution solution = new LevelOrderSolution();
            IList<IList<int>> result = solution.LevelOrder(root);

            Console.WriteLine("Level Order Traversal:");
            foreach (var level in result)
            {
                Console.WriteLine(string.Join(" ", level));
            }
        }
    }
}
