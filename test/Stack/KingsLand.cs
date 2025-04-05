using System;
namespace test.Stack
{
	public class KingsLand
	{
        //static void Main()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] land = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        //    int[] result = CalculateKingLandValues(n, land);
        //    Console.WriteLine(string.Join(" ", result));
        //}

        static int[] CalculateKingLandValues(int n, int[] land)
        {
            int[] prefixSum = GetPrefixSum(n, land);
            int[] left = GetLeftBounds(n, land);
            int[] right = GetRightBounds(n, land);
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = prefixSum[right[i] + 1] - prefixSum[left[i]];
            }

            return result;
        }

        static int[] GetPrefixSum(int n, int[] land)
        {
            int[] prefixSum = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + land[i];
            }
            return prefixSum;
        }

        static int[] GetLeftBounds(int n, int[] land)
        {
            int[] left = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && land[stack.Peek()] < land[i])
                    stack.Pop();

                left[i] = stack.Count == 0 ? 0 : stack.Peek() + 1;
                stack.Push(i);
            }

            return left;
        }

        static int[] GetRightBounds(int n, int[] land)
        {
            int[] right = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && land[stack.Peek()] <= land[i])
                    stack.Pop();

                right[i] = stack.Count == 0 ? n - 1 : stack.Peek() - 1;
                stack.Push(i);
            }

            return right;
        }
    }
}

