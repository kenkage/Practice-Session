using System;
namespace test.TGPC4
{
	public class SubArraySum
	{
		//static void Main()
		//{
  //          int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
  //          int result = SumSubarrayMins(arr);
  //          Console.WriteLine(result); 
  //      }

        static int SumSubarrayMins(int[] arr)
        {
            int n = arr.Length;
            int MOD = 1000000007;

            int[] prevLess = new int[n];
            int[] nextLess = new int[n];
            Stack<int> stack = new Stack<int>();

            // Fill prevLess array
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
                    stack.Pop();
                prevLess[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }

            stack.Clear();

            // Fill nextLess array
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                    stack.Pop();
                nextLess[i] = stack.Count == 0 ? n : stack.Peek();
                stack.Push(i);
            }

            long result = 0;

            // Calculate the sum of minimums
            for (int i = 0; i < n; i++)
            {
                long left = i - prevLess[i];
                long right = nextLess[i] - i;
                result = (result + arr[i] * left * right) % MOD;
            }

            return (int)result;
        }
    }
}

