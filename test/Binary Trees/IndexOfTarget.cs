using System;
using System.Reflection;

namespace test.BinaryTrees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left, right;

        public TreeNode(int val = 0)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class IndexOfTarget
	{
        public static TreeNode root;

		static void Main(string[] stirngs)
        {
            Console.WriteLine("Enter number of nodes in BST:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the values in level-order traversal (-1 for null nodes):");
            string[] inputs = Console.ReadLine().Split();

            foreach(string s in inputs)
            {
                Insert(int.Parse(s));
            }
            
            Console.WriteLine("Enter target integer:");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(FindInOrderIndex(target));
        }

        private static void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private static TreeNode InsertRec(TreeNode node, int val)
        {
            if (node == null) return new TreeNode(val);
            if (node.val > val)
            {
                node.left = InsertRec(node.left, val);
            } else
            {
                node.right = InsertRec(node.right, val);
            }
            return node;
        }

        public static int FindInOrderIndex(int target)
        {
            List<int> inOrderTraversal = new List<int>();
            PerformInOrderTraversal(root, inOrderTraversal);

            for (int i = 0; i < inOrderTraversal.Count; i++)
            {
                if (inOrderTraversal[i] == target)
                {
                    return i + 1; // 1-based index
                }
            }
            return -1; // Target not found
        }

        private static void PerformInOrderTraversal(TreeNode node, List<int> result)
        {
            if (node == null) return;

            PerformInOrderTraversal(node.left, result);
            result.Add(node.val);
            PerformInOrderTraversal(node.right, result);
        }
    }
}

